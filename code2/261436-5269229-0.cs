    using System;
    using System.Windows.Forms;
    
    class NopasteTextBox : TextBox {
        protected override void WndProc(ref Message m) {
            // Trap WM_PASTE:
            if (m.Msg == 0x302) return;
            base.WndProc(ref m);
        }
    }
