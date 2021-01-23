        timer = new System.Timers.Timer(10000);
        timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        timer.Enabled = true;
        ...
        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
           // check if connection is alive
           conneced = UltimateLibrary.http.HTTPUtility.isConnectionAvailable();
        }
