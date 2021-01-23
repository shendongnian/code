    class NoPasteRichTextBox : RichTextBox
    {
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        { 
            if (keyData == (Keys.Control | Keys.C))
            {
                return true;
            }
            
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
