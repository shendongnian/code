    bool ContainsOrIsRichTextBox(Control inputControl)
    {
        if(inputControl is RichTextBox) return true;
        foreach(Control control in inputControl.Controls)
        {
            if(ContainsOrIsRichTextBox(control)) return true;
        }
        return false;
    }
