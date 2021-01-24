    public void ConfigureServices(IServiceCollection services)
    {
    
        services.ConfigureApplicationCookie(options =>
        {
            options.AccessDeniedPath = "/YourCustomAccessDeniedPath";
        });
    }
