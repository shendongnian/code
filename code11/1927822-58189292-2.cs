    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc(setupAction =>
        {
            setupAction.Conventions.Add(new AddAuthorizeFilters ());
        });
    }
