    private void TextBox5_Validating(object sender, System.EventArgs e)
    {
        String AllowedChars = @"^a-zA-Z0-9.$";
        if(Regex.IsMatch(TextBox5.Text, AllowedChars))
        {
             e.Handled = true;
        }
        else
        {
             e.Handled = false;
        }
    }
