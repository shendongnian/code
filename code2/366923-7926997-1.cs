        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Don't click me. I want to be closed automatically!");
        }
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_CLOSE = 0xF060;
            if (m.Msg == WM_SYSCOMMAND) // this is sent even if a modal MessageBox is shown
            {
                if ((int)m.WParam == SC_CLOSE)
                {
                    CloseModalWindows();
                    Close();
                }
            }
            base.WndProc(ref m);
        }
