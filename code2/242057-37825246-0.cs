    private static string FormatAsRTF(string DirtyText)
    {
        System.Windows.Forms.RichTextBox rtf = new System.Windows.Forms.RichTextBox();
        rtf.Text = DirtyText;
        return rtf.Rtf;
    }
