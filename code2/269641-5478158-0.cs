    public void SpecialPaste()
    {
        var helperRichTextBox = new RichTextBox();
        helperRichTextBox.Paste();
        for(int i=0;i<helperRichTextBox.TextLength;++i)
        {
            helperRichTextBox.SelectionStart = i;
            helperRichTextBox.SelectionLength = 1;
            helperRichTextBox.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size,helperRichTextBox.SelectionFont.Style);
        }
        richTextBox1.SelectedRtf = helperRichTextBox.Rtf;
    }
