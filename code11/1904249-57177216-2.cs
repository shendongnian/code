    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();
        services.AddCors(options => options.AddPolicy("CorsPolicy",
        builder =>
        {
            builder.AllowAnyMethod()
            .AllowAnyHeader()
            .AllowAnyOrigin()
            .AllowCredentials();
        }));
        services.AddSignalR();
    }
