    RichTextBox r = new RichTextBox();
    r.Text = "This is a test";
    r.Select(r.Text.IndexOf("test"), "test".Length);
    r.SelectionFont = new Font(r.Font, FontStyle.Italic);
    r.SelectionStart = r.Text.Length;
    r.SelectionLength = 0;
