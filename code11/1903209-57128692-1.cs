    public void ConfigureServices(IServiceCollection services)
    {
      ...
      services
        .AddAuthentication()
        .AddJwtBearer();
    }
