        string oClipboard;
        private void TextBox1_GotFocus(object sender, System.EventArgs e)
        {
            oClipboard = Clipboard.GetText();
            Clipboard.SetText("foo");
        }
        private void TextBox1_LostFocus(object sender, System.EventArgs e)
        {
            Clipboard.SetText(oClipboard);
        }
