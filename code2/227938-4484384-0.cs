    using System;
    using System.Windows.Forms;
    
    class MyTextBox : TextBox {
        protected override void WndProc(ref Message m) {
            if (m.Msg == 0x102 && m.WParam.ToInt32() == '.') {
                m.WParam = (IntPtr)'/';   // test only
            }
            base.WndProc(ref m);
        }
    }
