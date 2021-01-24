    public static async Task CreateAdminAccount(IServiceProvider serviceProvider, IConfiguration configuration)
    {
        // get service scope factory (you could also pass this instead of the service provider)
        var serviceScopeFactory = serviceProvider.GetService<IServiceScopeFactory>();
        // create a scope
        using (var scope = serviceScopeFactory.CreateScope())
        {
            // resolve the services *within that scope*
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            // do stuff
        }
        // scope is terminated after the using ends, and all scoped dependencies will be cleaned up
    }
