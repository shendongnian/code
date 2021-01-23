        public delegate void OnLoggingEventHandler(object sender, LogEventArgs e);
        public event OnLoggingEventHandler OnLogging;
        
        private void Logging(string message)
        {
            LogEventArgs logMessage = new LogEventArgs();
            logMessage.messageEvent = message;
            if (OnLogging != null)
            {
                OnLogging(this, logMessage);
            }
        }
