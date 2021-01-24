    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("Any", 
                builder => 
                {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
        });
    }
    
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        app.UseCors("Any");
        // The others middlewares.
    }
