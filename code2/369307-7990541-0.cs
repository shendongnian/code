    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    class MyCalendar : MonthCalendar {
        public event MouseEventHandler RightClick;
        protected override void WndProc(ref Message m) {
            if (m.Msg == 0x205) {   // Trap WM_RBUTTONUP
                var handler = RightClick;
                if (handler != null) {
                    var me = new MouseEventArgs((MouseButtons)m.WParam.ToInt32(), 1,
                        m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16, 0);
                    handler(this, me);
                }
                this.Capture = false;
                return;
            }
            base.WndProc(ref m);
        }
    }
