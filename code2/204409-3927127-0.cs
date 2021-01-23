    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    class MyPanel : Panel, IMessageFilter {
        public MyPanel() {
            Application.AddMessageFilter(this);
        }
        protected override void Dispose(bool disposing) {
            if (disposing) Application.RemoveMessageFilter(this);
            base.Dispose(disposing);
        }
        public bool PreFilterMessage(ref Message m) {
            if (m.HWnd == this.Handle) {
                if (m.Msg == 0x201) {  // Trap WM_LBUTTONDOWN
                    Point pos = new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16);
                    // Do something with this, return true if the control shouldn't see it
                    //...
                    // return true
                }
            }
            return false;
        }
    }
