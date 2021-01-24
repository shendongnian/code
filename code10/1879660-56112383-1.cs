     using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetService<RedContext("alternateconnectionstringname")>();
                var roleManager = serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();
                var userManager = serviceScope.ServiceProvider.GetService<UserManager<ApplicationUser>>();
                // Create the Db if it doesn't exist and applies any pending migration.
                try
                {
                    dbContext.Database.Migrate();// throws exception if CS is wrong
                    DbSeeder.Seed(dbContext, roleManager, userManager);
                }
                catch (Exception ex)
                {                   
                }
    }
    
