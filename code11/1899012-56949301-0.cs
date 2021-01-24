    public void ConfigureServices(IServiceCollection services)
      {
        services.AddMvc();
        
        ApplicationInsightsServiceOptions aiOpts = 
          new ApplicationInsightsServiceOptions();
        aiOpts.EnableHeartbeat = true; // false to disable
        services.AddApplicationInsightsTelemetry(aiOpts);
        ...
    }
