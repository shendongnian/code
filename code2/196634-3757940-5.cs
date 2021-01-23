    void textbox_TextChanged(object sender, EventArgs e)
    {
        TextBox tb = (TextBox)sender;
        MessageBox.Show(tb.Text);
        // Do your changes here.
        // To Change focus from the current cell use
        SendKeys.Send("{TAB}"); // to give focus to next cell in the same row.
    }
