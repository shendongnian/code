    public void ConfigureServices(IServiceCollection services)
    {
 
        services.AddMvcCore()
        .AddAuthorization()
        .AddJsonFormatters();
 
        services.AddAuthentication("Bearer")
        .AddIdentityServerAuthentication(options =>
        {
            options.Authority = "http://localhost:5000";//IdentityServer4 Endpoint
            options.RequireHttpsMetadata = false;
 
            options.ApiName = "api1";//Name of resource
        });
 
    }
