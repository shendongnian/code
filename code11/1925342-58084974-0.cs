    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowMyOrigin",
                builder => builder.WithOrigins("links to origins"));
        });
    }
