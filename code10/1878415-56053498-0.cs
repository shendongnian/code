    public static void EnsureMigrationsAndInitialisationRun(this IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
        {
            var dbContextFactory = serviceScope.ServiceProvider.GetService<IDbContextFactory>();
            var allTenantConnectionStrings = serviceScope.ServiceProvider.GetService<ISessionServices>().AllTenantConnectionStrings();
            foreach (var tenantConnectionString in allTenantConnectionStrings)
            {
                var context = dbContextFactory.CreateDbContext(tenantConnectionString);
                context.Database.Migrate();
                // Add in the initializations here.
            }
        }
    }
Then you can call 
app.EnsureMigrationsAndInitialisationRun();
in your `Configure` method.
