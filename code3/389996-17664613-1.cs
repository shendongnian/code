    using System;
    using System.Windows.Forms;
    
    class MyTextBox : TextBox {
        protected override void WndProc(ref Message m) {
            // Change WM_LBUTTONDBLCLK to WM_LBUTTONCLICK
            if (m.Msg == 0x203) m.Msg = 0x201;
            base.WndProc(ref m);
        }
    }
