    public static IServiceCollection AddEFProject(this IServiceCollection services)
    {
       
        services.AddDbContext<YourDbContext>(o => o.UseSql //....);
        services.AddScoped<IRepo, Repo>();
        return services;
    }
