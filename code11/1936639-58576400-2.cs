    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers()            
            .AddJsonOptions(
                options => { 
                    options.JsonSerializerOptions.PropertyNamingPolicy = 
                        SnakeCaseNamingPolicy.Instance;
                });
    }
