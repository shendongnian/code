    public void ConfigureServices(IServiceCollection services)
    {
	   // Add detection services container and device resolver service.
        services.AddDetection();
        services.AddDetectionCore().AddBrowser();
        // Add framework services.
        services.AddMvc();
    }
