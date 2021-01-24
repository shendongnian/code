    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddTransient<IPrincipal>(
            provider => provider.GetService<IHttpContextAccessor>().HttpContext.User);
    
        // ...
    }
