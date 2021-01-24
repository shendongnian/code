C#
private void InputNumber_TextChanged (object sender, TextChangedEventArgs e) 
{
    string numberString = InputNumber.Text;
    if (!int.TryParse(numberString, out int number)) 
    {
        OutputNumber.Clear();
        return;
    }
    bool isEven = EvenOddChecker.IsEven(number);
    OutputNumber.Text = number + (isEven ? " is an even number" : " is an odd number");
    if (InputNumber.Text == string.Empty) 
    {
        OutputNumber.Clear();
    }
}
To check if the number is even this should be the fastest way:
C#
public static bool IsEven (int number) => number % 2 == 0;
