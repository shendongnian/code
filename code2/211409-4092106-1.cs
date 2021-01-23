    void GetTextBoxValues(Control c, List<string> strings)
    {
        TextBox t = c as TextBox;
        if (t != null)
            strings.Add(t.Text);
    
        foreach(Control child in c.Controls)
            GetTextBoxValues(child, strings);
    }
...
    List<string> strings = new List<string>();
    GetTextBoxValues(Page, strings);
