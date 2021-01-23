    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    using System.Text;
    
    [DefaultEvent("ValidateChar")]
    class ValidatingTextBox : TextBox {
        public event EventHandler<ValidateCharArgs> ValidateChar;
    
        protected virtual void OnValidateChar(ValidateCharArgs e) {
            var handler = ValidateChar;
            if (handler != null) handler(this, e);
        }
    
        protected override void OnKeyPress(KeyPressEventArgs e) {
            if (e.KeyChar >= ' ') {   // Allow the control keys to work as normal
                var args = new ValidateCharArgs(e.KeyChar);
                OnValidateChar(args);
                if (args.Cancel) {
                    e.Handled = true;
                    return;
                }
            }
            base.OnKeyPress(e);
        }
        private void HandlePaste() {
            if (!Clipboard.ContainsText()) return;
            string text = Clipboard.GetText();
            var toPaste = new StringBuilder(text.Length);
            foreach (char ch in text.ToCharArray()) {
                var args = new ValidateCharArgs(ch);
                OnValidateChar(args);
                if (!args.Cancel) toPaste.Append(ch);
            }
            if (toPaste.Length != 0) {
                Clipboard.SetText(toPaste.ToString());
                this.Paste();
            }
        }
    
        bool pasting;
        protected override void WndProc(ref Message m) {
            if (m.Msg == 0x302 && !pasting) {
                pasting = true;
                HandlePaste();
                pasting = false;
            }
            else base.WndProc(ref m);
        }
    }
    
    class ValidateCharArgs : EventArgs {
        public ValidateCharArgs(char ch) { Cancel = false; KeyChar = ch; }
        public bool Cancel { get; set; }
        public char KeyChar { get; set; }
    }
