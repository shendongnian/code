    private string oldClipboardContent { get; set; } = "";
    private bool pasteModified { get; set; } = false;
    private void TextBox_Pasting(object sender, DataObjectPastingEventArgs e)
    {
        if (pasteModified)
        {
            pasteModified = false;
        }
        else
        {
            pasteModified = true;
            string text = (string)e.DataObject.GetData(typeof(string));
            oldClipboardContent = text;
            Regex nonNumeric = new System.Text.RegularExpressions.Regex (@"\D");
            text = nonNumeric.Replace(text, string.Empty);
            e.CancelCommand();
                    
            Clipboard.SetData(DataFormats.Text, text);
            ApplicationCommands.Paste.Execute(text, this);
            Clipboard.SetData(DataFormats.Text, OldClipboardContent);
            oldClipboardContent = "";
        }
    }
