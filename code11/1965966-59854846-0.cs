    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors(options => 
        {
            options.AddPolicy("AnyName", builder =>
            {
                builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod()
               .AllowCredentials()
               .Build();
            });
        });
    }
