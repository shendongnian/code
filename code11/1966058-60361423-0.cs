    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers()
            .ConfigureApplicationPartManager(o =>
            {
                o.ApplicationParts.Clear();
                o.ApplicationParts.Add(new AssemblyPart(typeof(Startup).Assembly);
            });
    }
