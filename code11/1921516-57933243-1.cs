 csharp
private void OKButton_Click(object sender, RoutedEventArgs e)
{
    // this TryParse makes use of pattern matching
    if(int.TryParse(myTextBox.Text.Trim(), out var input) && input >= 0 && input <= 6)
    {
        // this should automatically convert to the name of the day of week
        // if not, add .ToString() at the end
        dayOutputLabel.Content = (DayOfWeek)input;
    }
    else
    {
        MessageBox.Show(
            text: "Please use a number between 0 and 6",
            caption: "Invalid Input",
            buttons: MessageBoxButtons.OK,
            icon: MessageBoxIcon.Error);
    }
}
And here is an another option using ```Enum.TryParse()``` instead:
 csharp
private void OKButton_Click(object sender, RoutedEventArgs e)
{
    // this TryParse makes use of pattern matching
    if(Enum.TryParse(myTextBox.Text.Trim(), out DayOfWeek input) &&
       input >= DayOfWeek.Sunday && input <= DayOfWeek.Saturday)
    {
        // this should automatically convert to the name of the day of week
        // if not, add .ToString() at the end
        dayOutputLabel.Content = input;
    }
    else
    {
        MessageBox.Show(
            text: "Please use a number between 0 and 6",
            caption: "Invalid Input",
            buttons: MessageBoxButtons.OK,
            icon: MessageBoxIcon.Error);
    }
}
