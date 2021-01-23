    void textbox1_Validating(object sender, CancelEventArgs e)
    {
        if (!System.Text.RegularExpressions.Regex.IsMatch(textbox1.Text, @"^[a-zA-Z]+$"))
        {
            MessageBox.Show("Please enter letters only");
        }
    }
