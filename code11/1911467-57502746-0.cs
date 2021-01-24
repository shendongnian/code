    // Startup.cs
    // ...
    public void ConfigureServices(IServiceCollection services)
    {
        services
            .AddAuthentication()
            .AddJwtBearer(
                authenticationScheme: "MY_AUTH_SCHEME", // NEW
                options =>
                {
                    options.Authority = "https://known.authority.url";
                });
    }
    // ...
