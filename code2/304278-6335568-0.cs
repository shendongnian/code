        protected override void OnStart(string[] args)
        {
            var aTimer = new Timer(600000);
            aTimer.Elapsed += ATimerElapsed;
            aTimer.Interval = 600000;
            aTimer.Enabled = true;
            GC.KeepAlive(aTimer);
        }
        private static currentlyRunning;
        private static void ATimerElapsed(object sender, ElapsedEventArgs e)
        {
            if(currentlyRunning) return;
            currentlyRunning = true;
            try
            {
                Worker.ProcessScheduledAudits();
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error);
            }
            currentlyRunning = false;
        }
