        public void InitTimer()
        {
            DateTime time = DateTime.Now;
            int second = time.Second;
            int minute = time.Minute;
            if (second != 0)
            {
                minute = minute > 0 ? minute-- : 59;
            }
            if (minute == 0 && second == 0)
            {
                // DoAction: in this function also set your timer interval to 3600000
            }
            else
            {
                TimeSpan span = new TimeSpan(0, 60 - minute, 60 - second);
                timer.Interval = (int) span.TotalMilliseconds - 100; 
                timer.Tick += new EventHandler(timer_Tick);
                timer.Start();
            }
        }
        void timer_Tick(object sender, EventArgs e)
        {
            timer.Interval = 3600000;
            // DoAction
        }
