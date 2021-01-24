    public IServiceCollection AddSecurity(this IServiceCollection)
    {
        services.AddAuthentication()
            .AddCookie();
        service.AddAuthorization(options =>
        {
            options.DefaultPolicy = …;
        });
        return services;
    }
