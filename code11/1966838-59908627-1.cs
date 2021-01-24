    public Startup(IConfiguration configuration, IHostingEnvironment env)
    {
       Configuration = configuration;
       //disable NLog assembly scanning
       NLog.Config.ConfigurationItemFactory.Default = new NLog.Config.ConfigurationItemFactory(typeof(NLog.ILogger).GetTypeInfo().Assembly);
       //here's where it hangs
       NLog.LogManager.LoadConfiguration(System.String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
    
        ...
    }
