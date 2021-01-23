    private void BoxChatAreaKeyPress(object sender, KeyEventArgs e)
    {
        var xBox = (RichTextBox)sender;
        // Setting a limit so the user cannot type more than 4000 characters at once
        var textRange = new TextRange(xBox.Document.ContentStart, xBox.Document.ContentEnd);
        var textLen = textRange.Text.Trim();
        if (textLen.Length <= 4000)
        {
            if ((textLen.Length > 1) && (e.Key == Key.Enter))
            {
                WriteMessage(xBox);
            }
        }
        else
        {
            e.Handled = true;
        }
    }
