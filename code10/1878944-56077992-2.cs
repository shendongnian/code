    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc().AddJsonOptions(o => {
            o.SerializerSettings.ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor;
        });
    }
