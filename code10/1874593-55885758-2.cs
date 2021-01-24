    public void ConfigureServices(IServiceCollection services)
    {
        // you can register them with any life time like that e.g. Singleton, Transient
        services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
    }
