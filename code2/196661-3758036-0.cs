    string _latestValidText = string.Empty;
    private void TextBox_TextChanged(object sender, EventArgs e)
    {
        TextBox target = sender as TextBox;
        if (ContainsNumber(target.Text))
        {
            // display alert and reset text
            MessageBox.Show("The text may not contain any numbers.");
            target.Text = _latestValidText;
        }
        else
        {
            _latestValidText = target.Text;
        }
    }
    private static bool ContainsNumber(string input)
    {
        return Regex.IsMatch(input, @"\d+");
    }
