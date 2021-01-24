    private void HighlightSearchText(string searchText, RichTextBox control)
    {
        // Make all text black first (this might be optional)
        control.SelectionStart = 0;
        control.SelectionLength = control.Text.Length;
        control.SelectionColor = System.Drawing.SystemColors.ControlText;
        var selStart = control.Text.IndexOf(searchText);
        if (selStart < 0) return;
        // Then color the search text
        control.SelectionStart = selStart;
        control.SelectionLength = searchText.Length;
        control.SelectionColor = Color.Red;
    }
