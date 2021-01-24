    public void ConfigureServices(IServiceCollection services)
    {
        services
            .AddMvc()
            .AddRazorPagesOptions(options =>
            {
                options.Conventions.AddPageRoute("/edit", "{handler?}/{id?}");
                options.Conventions.AddPageRoute("/create", "{handler?}");
            });
    }
