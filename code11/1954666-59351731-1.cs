    public void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<
            IMapToNew<Road, RoadDto>,
            MapToNewImplementation>();
    }
    
