    static ConventionSet BuildSqlServerConventionSet()
    {
    	var serviceProvider = new ServiceCollection()
    		.AddEntityFrameworkSqlServer()
    		.AddDbContext<DbContext>(o => o.UseSqlServer("Server=.").UseLazyLoadingProxies()) // <--
    		.BuildServiceProvider();
    
    	using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
    	{
    		using (var context = serviceScope.ServiceProvider.GetService<DbContext>())
    		{
    			return ConventionSet.CreateConventionSet(context);
    		}
    	}
    }
