    public static class Function
        {
            // Format in a CRON Expression e.g. {second} {minute} {hour} {day} {month} {day-of-week}
            // https://docs.microsoft.com/en-us/azure/azure-functions/functions-bindings-timer
            // [TimerTrigger("0 59 23 * * *") = 11:59pm
            [FunctionName("Function")]
            public static void Run([TimerTrigger("0 59 23 * * *")]TimerInfo myTimer, ILogger log)
            {
                
                // If running in debug then we dont want to load the appsettings.json file, this has its variables substituted in octopus
                // Running locally will use the local.settings.json file instead
    #if DEBUG
                IConfiguration config = new ConfigurationBuilder()
                    .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables()
                    .Build();
    #else
                IConfiguration config = Utils.GetSettingsFromReleaseFile();
    #endif
    
                // Initialise dependency injections
                var serviceProvider = Bootstrap.ConfigureServices(log4Net, config);
    
                var retryCount = Convert.ToInt32(config["RetryCount"]);
    
                int count = 0;
                while (count < retryCount)
                {
                    count++;
                    try
                    {
                        var business = serviceProvider.GetService<IBusiness>();
                        business.UpdateStatusAndLiability();
                        return;
                    }
                    catch (Exception e)
                    {
                        // Log your error
                    }
                }
                
            }
    
        }
