    class Program
        {
            static void Main(string[] args)
            {
                // Create DI container.
                IServiceCollection services = new ServiceCollection();
    
                var channel = new InMemoryChannel();
    
                services.Configure<TelemetryConfiguration>(
                  (config) =>
                    {
                        config.TelemetryChannel = channel;                    
                    }
               );
                
                // Add the logging pipelines to use. We are using Application Insights only here.
                services.AddLogging(loggingBuilder =>
                {
                    // Optional: Apply filters to configure LogLevel Trace or above is sent to ApplicationInsights for all
                    // categories.
                    loggingBuilder.AddFilter<ApplicationInsightsLoggerProvider>("", LogLevel.Trace);
                    loggingBuilder.AddApplicationInsights("***");
                });
    
                // Build ServiceProvider.
                IServiceProvider serviceProvider = services.BuildServiceProvider();
    
                ILogger<Program> logger = serviceProvider.GetRequiredService<ILogger<Program>>();
    
    
                logger.LogCritical("critical message working");
                // Begin a new scope. This is optional. Epecially in case of AspNetCore request info is already
                // present in scope.
                using (logger.BeginScope(new Dictionary<string, object> { { "Method", nameof(Main) } }))
                {
                    logger.LogWarning("Logger is working - warning"); // this will be captured by Application Insights.
    
                }
    
                channel.Flush();
                Thread.Sleep(1000);            
            }
        }
