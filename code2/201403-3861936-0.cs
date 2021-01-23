            [DllImport("user32.dll", EntryPoint = "GetDesktopWindow")]
        private static extern IntPtr GetDesktopWindow();
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);
        //...
        private const int SC_SCREENSAVE = 0xF140;
        private const int WM_SYSCOMMAND = 0x0112;
        //...
        public static void SetScreenSaverRunning()
        {
            SendMessage
        (GetDesktopWindow(), WM_SYSCOMMAND, SC_SCREENSAVE, 0);
        }
        public void Shakedetectionmouse(EventArgs e)
        {
            //CallTimer1_Tick
           timer1_Tick(this,e);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //ShowScreenSaver
            timer1.Enabled = true;
            timer1.Interval = 1000;
            SetScreenSaverRunning();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //ShowForm2
            using (var Form2 = new Form2())
            {
                Form2.ShowDialog();
            }
        }
