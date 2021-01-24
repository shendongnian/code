    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        base.ConfigureWebHost(builder);
    
        builder.ConfigureTestServices(servicesConfiguration =>
        {
            servicesConfiguration.AddScoped<IBarService>(di
                => new DecoratedBarService(di.GetRequiredService<BarService>()));
        });            
    }
