        public InitTimer()
        {
            Timer timer = new Timer();
            timer.Interval = 3 * 60 * 60 * 1000;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Enabled = true;
        }
        void timer_Tick(object sender, EventArgs e)
        {
            // Do what you need
            File.AppendAllText(log_file, your_message);
        }
