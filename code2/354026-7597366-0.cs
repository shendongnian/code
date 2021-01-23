    // Text change in Port text box
    private void txtPort_TextChanged(object sender, TextChangedEventArgs e)
    {
        // Only allow numeric input into the Port setting.
        Regex rxAllowed = new Regex(@"[^0-9]", RegexOptions.IgnoreCase);
        txtPort.Text = rxAllowed.Replace(txtPort.Text, ""); 
        txtPort.SelectionStart = txtPort.Text.Length; 
    }
