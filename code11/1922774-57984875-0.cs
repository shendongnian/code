    public void ConfigureServices (IServiceCollection services) {
        services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver (
            s.GetRequiredService));
    
        services.AddScoped<LandSchema>();
        services.AddGraphQL(x => {
                x.ExposeExceptions = true; //set true only in development mode. make it switchable.
            })
            .AddGraphTypes (ServiceLifetime.Scoped);
    }
