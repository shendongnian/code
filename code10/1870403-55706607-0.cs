    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(MyAllowSpecificOrigins,
            builder =>
            {
                builder.WithOrigins("http://example.com",
                                    "http://www.contoso.com");
            });
        });
        services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
    } 
