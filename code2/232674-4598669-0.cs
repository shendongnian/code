    using System;
    using System.Windows.Forms;
    
    class BackPanel : Panel {
        protected override void WndProc(ref Message m) {
            if (m.Msg == 0x84) m.Result = (IntPtr)(-1);
            else base.WndProc(ref m);
        }
    }
