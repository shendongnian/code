    private void TextBox1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
    {
        //Make sure that the textbox is not left blank
        if (string.IsNullOrEmpty(TextBox1.Text))
        {
            e.Cancel = true;
        }
    }
