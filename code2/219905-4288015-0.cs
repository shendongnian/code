    using System;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    class MyTextBox : TextBox {
        protected override void WndProc(ref Message m) {
            if (m.Msg == 0x20a && this.Parent != null) {
                PostMessage(this.Parent.Handle, m.Msg, m.WParam, m.LParam);
            }
            else base.WndProc(ref m);
        }
        [DllImport("user32.dll")]
        private static extern IntPtr PostMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
    }
