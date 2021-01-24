    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddMvc(options =>
        {
            options.ValueProviderFactories.Add(new BearerTokenValueProviderFactory());
        });
    }
