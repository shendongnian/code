    private void flowDocumentReader1_KeyUp(object sender, KeyEventArgs e)
    {
        // Check for CTRL+C
        if (e.Key == Key.C && Keyboard.Modifiers == ModifierKeys.Control)
        {
            // Get clipboard information
            IDataObject clipboardDataObject = Clipboard.GetDataObject();
                
            // Get list of available formats currently in clipboard
            string[] formatsInClipboard = clipboardDataObject.GetFormats();
            // Choose a format to use
            string desiredFormat = "Text"; // You can select Text, UnicodeText, Rich Text Format, etc.
                
            // Check for availability of desired format
            if (Array.IndexOf(formatsInClipboard, desiredFormat) >= 0)
            {
                // Get copied text
                string initialClipboardText = Clipboard.GetData(desiredFormat).ToString();
                // Update copied text
                string newClipboardText = InsertNameAndTimestamps(initialClipboardText);
                    
                // Insert updated text to clipboard
                Clipboard.SetData(desiredFormat, newClipboardText);
            }                
        }
    }
    // Sample text modification, modify however you like
    private string InsertNameAndTimestamps(string initialClipboardText)
    {
        return "[MODIFIED TEXT]" + initialClipboardText + "[MODIFIED TEXT]";
    }
