    bool m_modifiedPaste = false;
    private void TextBoxPaste(object sender, DataObjectPastingEventArgs args)
    {
        if (m_modifiedPaste == false)
        {
            m_modifiedPaste = true;
            string clipboard = args.DataObject.GetData(typeof(string)) as string;
            Regex nonNumeric = new System.Text.RegularExpressions.Regex(@"\D");
            string result = nonNumeric.Replace(clipboard, String.Empty);
            args.CancelCommand();
            Clipboard.SetData(DataFormats.Text, result);
            ApplicationCommands.Paste.Execute(result, uiTextBox);
        }
        else
        {
            m_modifiedPaste = false;
        }
    }
