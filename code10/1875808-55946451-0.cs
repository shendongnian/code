        public void WaitForSecond(int min)
        {
            System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
            if (min == 0 || min < 0) return;
            timer1.Interval = min * 1000;
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
