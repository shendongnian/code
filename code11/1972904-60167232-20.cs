    public void ConfigureServices(IServiceCollection services)
    {
            // ...other service registration 
            services.AddDbContext<EntityContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
    }
