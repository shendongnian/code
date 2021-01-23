        public UserService1() 
        {
            //Setup Service
            this.ServiceName = "MyService2";
            this.CanStop = true;
            this.CanPauseAndContinue = true;
            //Setup logging
            this.AutoLog = false;
            ((ISupportInitialize) this.EventLog).BeginInit();
            if (!EventLog.SourceExists(this.ServiceName))
            {
                EventLog.CreateEventSource(this.ServiceName, "Application");
            }
            ((ISupportInitialize) this.EventLog).EndInit();
            this.EventLog.Source = this.ServiceName;
            this.EventLog.Log = "Application";
        }
        protected override void OnStart(string[] args)
        {
            base.OnStart(args);
            this.EventLog.WriteEntry("In OnStart");
        }
