    public IServiceProvider ConfigureServices( IServiceCollection services )
    {
        var configuration = new Configuration().AddJsonFile( "MyConfig.json" );
        services.AddEntityFramework( configuration )
        // ...
    }
