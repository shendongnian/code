    private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyboardDevice.Modifiers == ModifierKeys.None && e.Key == Key.Enter)
        {
            e.Handled = true;
            // Do your special enter handling here...
        }
        // Shift+Enter (and any other keys) will be handled as normally...
        // ...you'll still get your new line on Shift+Enter
    }
