     public static void MigrateAndSeedDb(this IApplicationBuilder app, bool development = false)
            {
                using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
                using (var context = serviceScope.ServiceProvider.GetService<GatewayDbContext>())
                {
                    //your development/live logic here eg:
                    context.Migrate();
                    if(development)
                        context.Seed();
                }                
            }
    
            private static void Migrate(this GatewayDbContext context)
            {
                context.Database.EnsureCreated();
                if (context.Database.GetPendingMigrations().Any())
                    context.Database.Migrate();
            }
    
            private static void Seed(this GatewayDbContext context)
            {
                context.AddOrUpdateSeedData();
                context.SaveChanges();
            }
