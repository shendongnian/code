    static ThreadLocal<RichTextBox> rtfBox = new ThreadLocal<RichTextBox>(() => new RichTextBox());
    //convert RTF text to plain text
    public static string RtfTextToPlainText(string FormatObject )
    {
         rtfBox.Value.Rtf = FormatObject;
         FormatObject = rtfBox.Value.Text;
         rtfBox.Value.Clear();
         return FormatObject;
    }
