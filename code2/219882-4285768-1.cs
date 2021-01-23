    void textbox1_Validating(object sender, CancelEventArgs e)
    {
        if (!Regex.IsMatch(textbox1.Text, @"^[a-zA-Z]+$"))
        {
            MessageBox.Show("Please enter letters only");
        }
    }
