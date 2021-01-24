    public partial class MainWindow : Window
    {
        private readonly TelemetryClient telemetryClient;
        private static readonly ILog log = LogManager.GetLogger(typeof(MainWindow));
        public MainWindow()
        {
            //configure the key here for log4net
            TelemetryConfiguration.Active.InstrumentationKey = "the key";
            log4net.Config.XmlConfigurator.Configure();
            
            var config = new TelemetryConfiguration();
            
            //configure the key here for telemetry client
            config.InstrumentationKey = "the key";
            telemetryClient = new TelemetryClient(config);
    
            log.Info("wpf aaaa333");
            log.Info(TelemetryConfiguration.Active.TelemetryChannel.ToString());
    
            telemetryClient.TrackTrace("it is going to start!");
    
            InitializeComponent();
        }
    }
