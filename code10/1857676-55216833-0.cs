	public static IApplicationBuilder RunMigrations(this IApplicationBuilder app)
	{
		if (app == null)
			throw new ArgumentNullException(nameof(app));
		IEnumerable<IContextMigrator> autoMigrations = app.ApplicationServices.GetServices<IContextMigrator>();
		foreach (IContextMigrator migration in autoMigrations)
		{
		    migration.Migrate();
            // Other logic for dispose...
		}
		return app;
	}
	public static IServiceCollection AddDbContextWithMigration<TContext>(this IServiceCollection serviceCollection, Action<DbContextOptionsBuilder> optionsAction = null, ServiceLifetime contextLifetime = ServiceLifetime.Scoped, ServiceLifetime optionsLifetime = ServiceLifetime.Scoped) where TContext : DbContext
	{
        // By simply registering a transient of a wrapper-class I can resolve it later.
		serviceCollection.AddTransient<IContextMigrator, ContextMigrator<TContext>>();
		return serviceCollection.AddDbContext<TContext, TContext>(optionsAction, contextLifetime, optionsLifetime);
	}
