    using System;
    using System.Windows.Forms;
    
    class MyPanel : Panel {
        protected override void WndProc(ref Message m) {
            if (m.Msg == 0x20) {  // Trap WM_SETCURSOR
                Cursor.Current = Cursors.Default;
                m.Result = (IntPtr)1;
            }
            else base.WndProc(ref m);
        }
    }
