    public void ConfigureServices(IServiceCollection services)
    {
    	services.AddMvc();
        // Other stuff...
        services.AddDbContext<UserGameKeyContext>();
    }
