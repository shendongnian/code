    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        foreach (var control in stackpanel.Children)
        {
            if (control is TextBox)
            {
                TextBox textBox = control as TextBox;
                textBox.LostFocus += TextBox_LostFocus;
            }
        }
    }
    private void TextBox_LostFocus(object sender, RoutedEventArgs e)
    {
        TextBox textBox = sender as TextBox;
        if (textBox != null)
        {
            if (textBox.Text !="")
            {
                feet = FeetConversion(textBox.Text.Trim());
                textBox.Text = ConvertDecimalToFraction(feet);
            }
        }
    }
