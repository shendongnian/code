    class NoPasteRichTextBox : RichTextBox
    {
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        { 
            if (keyData == (Keys.Control | Keys.V) &&
                Clipboard.GetText().Contains("\n"))
            {
                return true;
            }
            
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
