    private void textBox_Enter(object sender, System.EventArgs e)
    {
        if (sender is TextBox textbox)
        {
            textbox.SelectionStart = 0;
            textbox.SelectionLength = textbox.Text.Length;
        }
    }
