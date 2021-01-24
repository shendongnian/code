    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        // …
        builder.ConfigureTestServices(services =>
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("TestDB"));
        });
    }
