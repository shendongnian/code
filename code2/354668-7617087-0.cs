    private void TextBoxPaste(object sender, DataObjectPastingEventArgs args)
    {
        string clipboard = args.DataObject.GetData(typeof(string)) as string;
        Regex nonNumeric = new System.Text.RegularExpressions.Regex(@"\D");
        string result = nonNumeric.Replace(clipboard, String.Empty);
        int start = uiTextBox.SelectionStart;
        int length = uiTextBox.SelectionLength;
        int caret = uiTextBox.CaretIndex;
        string text = uiTextBox.Text.Substring(0, start);
        text += uiTextBox.Text.Substring(start + length);
        string newText = text.Substring(0, uiTextBox.CaretIndex) + result;
        newText += text.Substring(caret);
        uiTextBox.Text = newText;
        uiTextBox.CaretIndex = caret + result.Length;
        args.CancelCommand();
    }
