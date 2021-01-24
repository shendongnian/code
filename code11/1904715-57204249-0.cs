private string oldClipboardContent { get; set; } = "";
 private void Window_Activated(object sender, EventArgs e)
        {
            Clipboard.SetText(oldClipboardContent);
        }
        private void Window_Deactivated(object sender, EventArgs e)
        {
            oldClipboardContent = Clipboard.GetText();
            Clipboard.Clear();
        }
