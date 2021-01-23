    private void ValidateBtn_Click(Object Sender, EventArgs E)
    {
        Page.Validate();
        if (Page.IsValid == true)  // yes, it is written this way in the MSDN documentation
            lblOutput.Text = "Page is Valid!";
        else
            lblOutput.Text = "Some required fields are empty.";
    }
