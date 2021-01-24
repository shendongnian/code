    using System.Diagnostics;
    using System.ServiceProcess;
    using Logic;
    namespace ScriptRunnerService
    {
    public partial class ScriptRunService : ServiceBase
    {
        public ScriptRunService()
        {
            InitializeComponent();
            eventLog1 = new EventLog();
            if (!EventLog.SourceExists("MySource"))
            {
                EventLog.CreateEventSource(
                    "MySource", "MyNewLog");
            }
            eventLog1.Source = "MySource";
            eventLog1.Log = "MyNewLog";
            var runMyScript = new RunScript();
            var output = runMyScript.Start();
            eventLog1.WriteEntry(output.ToString(), EventLogEntryType.Information);
        }
        protected override void OnStart(string[] args)
        {
            eventLog1.WriteEntry("In OnStart.", EventLogEntryType.Information);
        }
        protected override void OnStop()
        {
            eventLog1.WriteEntry("In OnStop.", EventLogEntryType.Information);
        }
      }
    }
