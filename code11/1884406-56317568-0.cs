    private static void ConfigureApplicationLogging(WebHostBuilderContext context, ILoggingBuilder loggingBuilder)
    {
        var fancyService = loggingBuilder.Services.BuildServiceProvider().GetService<IFancyService>();
        fancyService.Initialize();
        var loggingConfiguration = context.Configuration.GetSection("Logging");
        loggingBuilder.AddConfiguration(loggingConfiguration);
        if (fancyService.IsEnabled)
            loggingBuilder.AddEventLog(loggingConfiguration);
    }
