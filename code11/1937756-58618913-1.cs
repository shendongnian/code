    public void ConfigureServices(IServiceCollection services)
    {
        // AddDbContext
        var sp = services.BuildServiceProvider();
        var dbContext = sp.GetRequiredService<DbContext>();
        Project project = new Project(dbContext); 
        services.AddSingleton(typeof(Project), project);
    }
