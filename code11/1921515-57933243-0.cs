 csharp
private void OKButton_Click(object sender, RoutedEventArgs e)
{
    // this TryParse makes use of pattern matching
    if(int.TryParse(myTextBox.Text.Trim(), out var input) && input >= 0 && input <= 6)
    {
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
