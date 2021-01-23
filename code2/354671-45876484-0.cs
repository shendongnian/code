    private void TextBox_Pasting(object sender, DataObjectPastingEventArgs e)
    {
        string clipboard = e.DataObject.GetData(typeof(string)) as string;
        Regex nonNumeric = new System.Text.RegularExpressions.Regex (@"\D");
        string result = nonNumeric.Replace(clipboard, string.Empty);
        int caret = CaretIndex;
        Text = Text.Substring(0, SelectionStart) + result +
            Text.Substring(SelectionStart + SelectionLength);
        CaretIndex = caret + result.Length;
        e.CancelCommand();
    }
