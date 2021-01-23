    class Monitor
    {
        FileSystemWatcher _fsw;
        Timer _notificationTimer;
        List<string> _filePaths = new List<string>();
    
        public Monitor() {
            _notificationTimer = new Timer();
            _notificationTimer.Elapsed += notificationTimer_Elapsed;
            // CooldownSeconds is the number of seconds the Timer is 'extended' each time a file is added.
            // I found it convenient to put this value in an app config file.
            _notificationTimer.Interval = CooldownSeconds * 1000;
    
            _fsw = new FileSystemWatcher();
            // Set up the particulars of your FileSystemWatcher.
            _fsw.Created += fsw_Created;
        }
    
        private void notificationTimer_Elapsed(object sender, ElapsedEventArgs e) {
            //
            // Do what you want to do with your List of files.
            //
    
            // Stop the timer and wait for the next batch of files.            
            _notificationTimer.Stop();
            // Clear your file List.
            _filePaths = new List<string>();
        }
    
    
        // Fires when a file is created.
        private void fsw_Created(object sender, FileSystemEventArgs e) {
            // Add to our List of files.
            _filePaths.Add(e.Name);
    
            // 'Reset' timer.
            _notificationTimer.Stop();
            _notificationTimer.Start();
        }
    }
