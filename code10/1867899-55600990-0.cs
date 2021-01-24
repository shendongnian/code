    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        base.ConfigureWebHost(builder);
        builder.ConfigureTestServices(servicesConfiguration =>
        {
            servicesConfiguration.AddHttpContextAccessor();
            servicesConfiguration.AddScoped<IBarService>(di =>
            {
                var httpContextAccessor = di.GetRequiredService<IHttpContextAccessor>();
                var hostServiceScope = Server.Host.Services.CreateScope();
                httpContextAccessor.HttpContext.Response.RegisterForDispose(hostServiceScope);
                return new DecoratedBarService(
                    hostServiceScope.ServiceProvider.GetRequiredService<BarService>());
            });
        });
    }
