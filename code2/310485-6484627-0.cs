        protected override void WndProc(ref Message m) {
            if (m.Msg == 0x20) {  // Trap WM_SETCUROR
                if ((m.LParam.ToInt32() & 0xffff) == 2) { // Trap HTCAPTION
                    Cursor.Current = Cursors.Hand;
                    m.Result = (IntPtr)1;  // Processed
                    return;
                }
            }
            base.WndProc(ref m);
        }
