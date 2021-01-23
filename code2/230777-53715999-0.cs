    using System.Diagnostics;
    using System.ServiceProcess;
    public partial class VaultServerUtilities : ServiceBase
    {
        public static string ServiceVersion { get; private set; }
        public VaultServerUtilities()
        {
            InitializeComponent();
            VSUEventLog = new EventLog();
            if (!EventLog.SourceExists("Vault Server Utilities"))
            {
                EventLog.CreateEventSource("Vault Server Utilities", "Service Log");
            }
            VSUEventLog.Source = "Vault Server Utilities";
            VSUEventLog.Log = "Service Log";
        }
       
        protected override void OnStart(string[] args)
        {
            ServiceVersion = typeof(Program).Assembly.GetName().Version.ToString();
            VSUEventLog.WriteEntry(string.Format("Vault Server Utilities v{0} has started successfully.", ServiceVersion));
        }
        protected override void OnStop()
        {
            VSUEventLog.WriteEntry(string.Format("Vault Server Utilities v{0} has be shutdown.", ServiceVersion));
        }
    }
