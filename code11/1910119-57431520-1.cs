    private void textBox_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
    {
        if (!Regex.IsMatch(sender.Text, @"^-?\d+\.?\d+[-+*\/]-?\d+\.?\d+$") && sender.Text != "")
        {
            int position = sender.SelectionStart - 1;
            sender.Text = sender.Text.Remove(position, 1);
            sender.SelectionStart = position;
        }
    }
