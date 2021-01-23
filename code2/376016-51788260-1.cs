    using System.Diagnostics;
    using System.ServiceProcess;
    namespace TimerService
    {
        public partial class Timer_Service : ServiceBase
        {
            public Timer_Service()
            {
                InitializeComponent();
            }
            static void Main()
            {
                if (System.Diagnostics.Debugger.IsAttached)
                {
                    Timer_Service service = new Timer_Service();
                    service.OnStart(null);
                }
                else
                {
                    ServiceBase[] ServicesToRun;
                    ServicesToRun = new ServiceBase[]
                    {
                        new Timer_Service()
                    };
                    ServiceBase.Run(ServicesToRun);
                }
            }
            protected override void OnStart(string[] args)
            {
                EventLog.WriteEvent("Timer_Service", new EventInstance(0, 0, EventLogEntryType.Information), new string[] { "Service start successfully." });
            }
            protected override void OnStop()
            {            
                EventLog.WriteEvent("Timer_Service", new EventInstance(0, 0, EventLogEntryType.Information), new string[] { "Service stop successfully." });
            }
        }
    }
