    public void SpecialPaste()
    {
        var helperRichTextBox = new RichTextBox();
        helperRichTextBox.Paste();
        helperRichTextBox.SelectionStart = 0;
        helperRichTextBox.SelectionLength = 1;
    Font lastFont = helperRichTextBox.SelectionFont;
    int lastFontChange = 0;
    for (int i = 0; i < helperRichTextBox.TextLength; ++i)
    {
        helperRichTextBox.SelectionStart = i;
        helperRichTextBox.SelectionLength = 1;
        if (!helperRichTextBox.SelectionFont.Equals(lastFont))
        {
            lastFont = helperRichTextBox.SelectionFont;
            helperRichTextBox.SelectionStart = lastFontChange;
            helperRichTextBox.SelectionLength = i - lastFontChange;
            helperRichTextBox.SelectionFont = new Font(richTextBox1.Font.FontFamily, richTextBox1.Font.Size, helperRichTextBox.SelectionFont.Style);
            lastFontChange = i;
        }
    }
    helperRichTextBox.SelectionStart = helperRichTextBox.TextLength-1;
    helperRichTextBox.SelectionLength = 1;
    helperRichTextBox.SelectionFont = new Font(richTextBox1.Font.FontFamily, richTextBox1.Font.Size, helperRichTextBox.SelectionFont.Style);
    richTextBox1.Rtf = helperRichTextBox.Rtf;
}
