    public static ConventionSet Build()
    {
        var serviceProvider = new ServiceCollection()
            .AddEntityFrameworkSqlServer()
            .AddDbContext<DbContext>(o => o.UseSqlServer("Server=."))
            .BuildServiceProvider();
    
        using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
        {
            using (var context = serviceScope.ServiceProvider.GetService<DbContext>())
            {
                return ConventionSet.CreateConventionSet(context);
            }
        }
    }
