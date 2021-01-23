    using System;
    using System.Windows.Forms;
    
    class MyTabControl : TabControl {
        protected override void OnHandleCreated(EventArgs e) {
            base.OnHandleCreated(e);
            // Send TCM_SETMINTABWIDTH
            SendMessage(this.Handle, 0x1300 + 49, IntPtr.Zero, (IntPtr)10);
        }
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
    }
