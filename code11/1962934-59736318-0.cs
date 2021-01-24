    public static async Task Main(string[] args)
    {
        ConfigureNLog();
        Logger logger = LogManager.GetCurrentClassLogger();
        logger.Info("my test log entry");
    }
    static void ConfigureNLog()
    {
        var config = new LoggingConfiguration();
        var consoleTarget = new ColoredConsoleTarget();
        config.AddTarget("console", consoleTarget);
        var awsTarget = new AWSTarget()
        {
            LogGroup = "NLog.ProgrammaticConfigurationExample",
            Region = "eu-west-1"
        };
        config.AddTarget("aws", awsTarget);
        config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, consoleTarget));
        config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, awsTarget));
        LogManager.Configuration = config;
    }
