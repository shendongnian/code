        private static readonly ILog log = LogManager.GetLogger(typeof(MainWindow));
        public MainWindow()
        {
            TelemetryConfiguration.Active.InstrumentationKey = "the key";
            log4net.Config.XmlConfigurator.Configure();
    
            log.Info("wpf aaaa11111");
    
    
            InitializeComponent();
        }
        }    
