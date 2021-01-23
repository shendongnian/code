        protected override void OnStart(string[] args)
        {
            try
            {
                // Using a timer Event to start asynchronously
                StartupTimer = new Timer();
                StartupTimer.Elapsed += StartupTimer_Elapsed;
                StartupTimer.AutoReset = false;
                StartupTimer.Interval = 5*60*1000;
                StartupTimer.Start();
            }
            catch (Exception ex)
            {
                LogMessage(true, ex.ToString());
            }
        }
		
        private void StartupTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                RunSetup(true);
            }
            catch (Exception ex)
            {
                LogMessage(true, ex.ToString());
            }
        }
