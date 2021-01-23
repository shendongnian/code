    public static ILog Log;
    
    static void Main(string[] args)
    {
        // Setup Logging
        log4net.Config.XmlConfigurator.Configure();
        Log = LogManager.GetLogger("MyAwesomeApp");
        
        // ...
    }
