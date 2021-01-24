    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSignalR(hubOptions =>
        {
            hubOptions.EnableDetailedErrors = true;
            hubOptions.KeepAliveInterval = TimeSpan.FromMinutes(1);
        });
    }
    
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        app.UseRouting();
    
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapHub<MyHub>("/myhub", options =>
            {
                options.Transports = HttpTransportType.LongPolling; // you may also need this
            });
        });
    }
