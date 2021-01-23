    private static readonly log4net.ILog log = log = log4net.LogManager.GetLogger(typeof(PTSentryService));
    static PTSentryService()
    {
        // Initialize log4net.
        log4net.Config.XmlConfigurator.Configure();
    }
