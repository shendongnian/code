    using System.Text.RegularExpressions;
    
    // Add chars which you don't want the user to be able to enter
    private Regex regularExpression = new Regex(@"!@#$%^&*().", RegexOptions.IgnoreCase);
    // Your text changed event handler
    private void txtInput_TextChanged(object sender, TextChangedEventArgs e)
    {
        // Replace the forbidden char with ""
        txtInput.Text = regularExpression.Replace(txtInput.Text, "");
        txtInput.SelectionStart = txtInput.Text.Length;
    }
