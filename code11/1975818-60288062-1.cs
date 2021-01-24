    public void ConfigureServices(IServiceCollection services)
    {
        ...
        // this method allows you to configure you DbContext options
        services.AddDbContext<YourDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
    
        ...
    }
