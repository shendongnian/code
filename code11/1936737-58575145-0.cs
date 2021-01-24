    public void Configure(IApplicationBuilder app, IServiceProvider serviceProvider)
    {
        ApplicationDbContext.CreateAdminAccount(serviceProvider, Configuration)
            .Wait();
    }
