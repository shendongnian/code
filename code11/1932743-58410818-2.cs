    public void ConfigureServices(IServiceCollection services)
    {
        services.Configure<FilteringRequestSettings>(this.Configuration.GetSection("FilteringRequest"));
    
        services.AddControllers();
    }
