    public virtual void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc()
            .AddJsonOptions(j =>
            {
                j.SerializerSettings.ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                };
            });
    }
