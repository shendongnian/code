        protected override bool ProcessKeyPreview(ref System.Windows.Forms.Message m)
        {
            int _ENTER = 13;
            int _KEYUP = 257;
            if (m.Msg == _ENTER && (int)m.WParam == _KEYUP)
            {
                Application.Exit();
            }
            return base.ProcessKeyPreview(ref m);
        }
