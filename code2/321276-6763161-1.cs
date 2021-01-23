    if (MessageBoxMessageHasFocus == true)
    {
        MessageBoxMessage.Text = "";
        MessageBoxMessage.SetValue(TextBox.TextProperty, "");
    }
    else
    {
        MessageBoxMessage.Text = "new message";
        MessageBoxMessage.SetValue(TextBox.TextProperty, "new message");
    }
