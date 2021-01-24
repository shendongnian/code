            public void ConfigureServices(IServiceCollection services)
            {
                //your other code
    
                services.AddApplicationInsightsTelemetry();
                services.AddApplicationInsightsTelemetryProcessor<MyTelemetryProcessor>();
            }
