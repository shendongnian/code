        public partial class CrowdCodeService : ServiceBase
        {
            private Timer stateTimer;
            private TimerCallback timerDelegate;
            AutoResetEvent autoEvent = new AutoResetEvent(false);
    
            public CrowdCodeService()
            {
                InitializeComponent();
            }
            int secondsDefault = 30;
            int secondsIncrementError = 30;
            int secondesMaximum = 600;
            int seconds;
            protected override void OnStart(string[] args)
            {
                Loggy.Add("Starting CrowdCodeService.");
                timerDelegate = new TimerCallback(DoSomething);
                seconds = secondsDefault;
                stateTimer = new Timer(timerDelegate, autoEvent, 0, seconds * 1000);
            }
    
            static bool isRunning = false;
    
            // The state object is necessary for a TimerCallback.
            public void DoSomething(object stateObject)
            {
                if (CrowdCodeService.isRunning)
                {
                    return;
                }
                CrowdCodeService.isRunning = true;
                AutoResetEvent autoEvent = (AutoResetEvent)stateObject;
                try
				{
                
					////// Do your work here
					
					
                    string cs = "Application";
                    EventLog elog = new EventLog();
                    if (!EventLog.SourceExists(cs))
                        {
                            EventLog.CreateEventSource(cs, cs);
                        }
                        elog.Source = cs;
                        elog.EnableRaisingEvents = true;
    
                        elog.WriteEntry("CrowdCodes Service Error:" + cmd.Message.ToString(), EventLogEntryType.Error, 991);
                    }
                }
                finally
                {    
                    CrowdCodeService.isRunning = false;
                }
    
            }
    
    
            protected override void OnStop()
            {
                Loggy.Add("Stopped CrowdCodeService.");
                stateTimer.Dispose();
            }
        }
