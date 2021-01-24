    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton(new MbTilesReader("c:/temp/map.mbtiles"));
        services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
    }
