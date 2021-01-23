        private void OnMinimize() {
            this.Close();   // Do your stuff
        }
        protected override void WndProc(ref Message m) {
            // Trap WM_SYSCOMMAND, SC_MINIMIZE
            if (m.Msg == 0x112 && m.WParam.ToInt32() == 0xf020) {
                OnMinimize();
                return;        // NOTE: delete if you still want the default behavior
            }
            base.WndProc(ref m);
        }
