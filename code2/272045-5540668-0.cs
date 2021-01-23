        private Point Pos;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312)   // Trap WM_HOTKEY
            {
                switch (m.WParam.ToInt32()) {
                   case 0: Pos = Cursor.Position; break;
                   case 1: Cursor.Position = Pos; break;
                }
            }
            base.WndProc(ref m);
        }
