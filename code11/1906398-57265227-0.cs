    public void ConfigureServices(IServiceCollection services)
    {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAnyOrigin",
                    builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
    
            // other code           
    }
    public void Configure(IApplicationBuilder app)
    {
        app.UseCors("AllowAnyOrigin");
    
        // ...
    }
