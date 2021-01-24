    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc(o =>
        {
            var policy = new AuthorizationPolicyBuilder()
                .RequireRole("Admin")
                .Build();
            o.Filters.Add(new AuthorizeFilter(policy));
        });
    }
