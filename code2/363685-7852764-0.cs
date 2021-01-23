    using System;
    using System.Windows.Forms;
    
    class MyTextBox : TextBox {
        protected override void WndProc(ref Message m) {
            // Trap WM_PASTE:
            if (m.Msg == 0x302 && Clipboard.ContainsText()) {
                this.SelectedText = Clipboard.GetText().Replace('\n', ' ');
                return;
            }
            base.WndProc(ref m);
        }
    }
