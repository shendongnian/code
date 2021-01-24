    public void ConfigureServices(IServiceCollection services)
    {                    
        services.AddDbContext<MyDbContext>(options => options.UseSqlServer(...));
        services.AddScoped<IGenericRepository<MyModel>, GenericRepository<MyModel>>();
        services.AddScoped<IMyDbContext, MyDbContext>();
    }
