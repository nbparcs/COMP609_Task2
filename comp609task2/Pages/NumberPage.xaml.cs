using System.Text;

namespace comp609task2.Pages;

public partial class NumberPage : ContentPage
{
    public NumberPage()
    {
        InitializeComponent();
    }
    private void GetPrimesBtn_click(object sender, EventArgs e)
    {
        if (IsValidInput(Input1.Text) && IsValidInput(Input2.Text))
        {
            int start = ExtractNumber(Input1.Text);
            int end = ExtractNumber(Input2.Text);

            int startset1 = (start < end) ? start : end;
            int endset1 = (start < end) ? end : start;

            List<int> primes1 = GetPrimes(start, end);

            ResultLabel.Text = $"Prime numbers between {start} and {end}: {string.Join(", ", primes1)}";
        }
        else
        {
            DisplayAlert("Error", "Invalid Input", "OK");
        }
    }
    static int ExtractNumber(string input)
    {
        int number = 0;
        foreach (char c in input)
        {
            if (char.IsDigit(c))
            {
                number = number * 10 + (c - '0');
            }
        }
        return number;
    }

    static bool IsValidInput(string input)
    {
        return !string.IsNullOrWhiteSpace(input) &&
               int.TryParse(input.Replace(",", ""), out _);
    }

    static List<int> GetPrimes(int start, int end)
    {
        List<int> primes = new List<int>();
        for (int i = Math.Min(start, end); i <= Math.Max(start, end); i++)
        {
            if (IsPrime(i))
            {
                primes.Add(i);
            }
        }
        return primes;
    }
    public static bool IsPrime(int number)
    {
        if (number < 2)
            return false;
        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0)
                return false;
        }
        return true;
    }
    private void ResetButton_Clicked(object sender, EventArgs e)
    {
        Input1.Text = string.Empty;
        Input2.Text = string.Empty;

        ResultLabel.Text = string.Empty;
    }
}