        protected override void WndProc(ref Message m) {
            base.WndProc(ref m);
            // Trap WM_ACTIVATE when we get active
            if (m.Msg == 6 && m.WParam.ToInt32() == 1) {
                if (Control.FromHandle(m.LParam) == null) {
                    Console.WriteLine("activated from another process");
                }
            }
        }
