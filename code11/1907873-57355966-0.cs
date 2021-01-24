    public static class WebHostBuilderCustomExtension
    {
        public static IWebHostBuilder AddKeyVault(this IWebHostBuilder builder)
        {
            return builder.ConfigureAppConfiguration(
                            (context, config) =>
                            {
                                var loggerFactory = new LoggerFactory(); 
                                loggerFactory.AddConsole();
                                var logger = loggerFactory.CreateLogger(typeof(WebHostBuilderCustomExtension));
                                logger.LogInformation($"connected to key vault ");
                            });
        }
    }
