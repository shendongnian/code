    private void textBox_KeyDown(object sender, KeyEventArgs e)
    {
        Control textbox = sender as TextBox;
        if (textbox != null) // Safety check
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Check if next control is a text-box and send focus to it.
                Control nextControl = GetNextControl(textbox, true);
                if (nextControl is TextBox)
                {
                    SelectNextControl(textbox, true, true, false, false);
                }
            }
        }
    }
