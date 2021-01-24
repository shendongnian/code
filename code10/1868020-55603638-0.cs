    using (TextReader tr = new StreamReader(@"c:\1.sql"))
    {
    sideBySideRichTextBox1.LeftText = tr.ReadToEnd();
    }
    using (TextReader tr = new StreamReader(@"c:\2.sql"))
    {
    sideBySideRichTextBox1.RightText = tr.ReadToEnd();
    }
    sideBySideRichTextBox1.CompareText();
