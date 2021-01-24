    private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        const int MAX_LINE_LENGTH = 20;
        var textbox = sender as TextBox;
        var exceedsLength = false;
        // First test if we need to modify the text
        for (int i = 0; i < textbox.LineCount; i++)
        {
            if (textbox.GetLineLength(i) > MAX_LINE_LENGTH)
            {
                exceedsLength = true;
                break;
            }
        }
        if (exceedsLength)
        {
            // Split the text into lines
            string[] oldTextArray = textbox.Text.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            var newTextLines = new List<string>(textbox.LineCount);
            for (int k = 0; k < oldTextArray.Length; k++)
            {
                // truncate each line
                newTextLines.Add(string.Concat(oldTextArray[k].Take(MAX_LINE_LENGTH)));
            }
            // Save the cursor position
            var cursorPos = textbox.SelectionStart;
            // To avoid the text change calling back into this event, detach the event while setting the Text property
            textbox.TextChanged -= TextBox_TextChanged;
            // Set the new text
            textbox.Text = string.Join(Environment.NewLine, newTextLines);
            textbox.TextChanged += TextBox_TextChanged;
            // Restore the cursor position
            textbox.SelectionStart = cursorPos;
            // if at the end of the line, the position will advance automatically to the next line, supress that
            if (textbox.SelectionStart != cursorPos)
            {
                textbox.SelectionStart = cursorPos - 1;
            }
        }
        e.Handled = true;
    }
