    using System;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    
    class MyListView : ListView {
        public event EventHandler TopItemChanged;
        protected virtual void OnTopItemChanged(EventArgs e) {
            var handler = TopItemChanged;
            if (handler != null) handler(this, e);
        }
        protected override void WndProc(ref Message m) {
            // Trap LVN_ENDSCROLL, delivered with a WM_REFLECT + WM_NOTIFY message
            if (m.Msg == 0x204e) {
                var notify = (NMHDR)Marshal.PtrToStructure(m.LParam, typeof(NMHDR));
                if (notify.code == -181 && !this.TopItem.Equals(lastTopItem)) {
                    OnTopItemChanged(EventArgs.Empty);
                    lastTopItem = this.TopItem;
                }
            }
            base.WndProc(ref m);
        }
        private ListViewItem lastTopItem = null;
        private struct NMHDR {
            public IntPtr hwndFrom;
            public IntPtr idFrom;
            public int code;
        }
    }
