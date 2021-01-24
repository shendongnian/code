    public void ConfigureServices(IServiceCollection services) {
        var section = this.Configuration.GetSection(nameof(Section));
        if (!section.Exists()) throw new Exception();
        services.Configure<Section>(section);
    }
