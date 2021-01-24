        public void Wait(int sec)
        {
            System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
            if (sec == 0 || sec < 0) return;
            timer1.Interval = sec * 1000;
            timer1.Enabled = true;
            timer1.Start();
            timer1.Tick += (s, e) =>
            {
                timer1.Enabled = false;
                timer1.Stop();
            };
            while (timer1.Enabled)
            {
                Application.DoEvents();
            }
        }
