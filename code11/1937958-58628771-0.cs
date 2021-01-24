    var user = new User
    {
        Id = new Guid("a1add451-7dd2-46fd-9877-1996e3f1fb4c").ToString(),
        Email = "",
        NormalizedEmail = "".ToUpper(),
        UserName = "",
        NormalizedUserName = "tony5".ToUpper(),
        EmailConfirmed = true,
        PhoneNumberConfirmed = true,
        LockoutEnabled = false,
        SecurityStamp = Guid.NewGuid().ToString()
    };
    
    using (var context = new ApplicationDbContext(
        serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
    {
        var roles = new[]
            {"Owner", "Administrator", "Editor", "ContentWriter"};
    
        var roles1 = new[]
            {"Administrator"};
    
        var roles2 = new[]
            {"Editor"};
    
        var roles4 = new[]
            {"Owner", "Administrator"};
    
        if (!context.Roles.Any())
        {
            foreach (var role in roles)
            {
                var roleStore = new RoleStore<ApplicationRole>(context);
    
                await roleStore.CreateAsync(new ApplicationRole
                {
                    Name = role,
                    NormalizedName = role.ToUpper()
                });
            }
        }
    
        if (!context.Users.Any())
        {
            await SeedUser(user, context, serviceProvider, roles4);
        }
    }
    
    
    private static async Task SeedUser(
        User user, 
        ApplicationDbContext context, 
        IServiceProvider serviceProvider,
    	string[] roles)
    {
        var password = new PasswordHasher<User>();
        var hashed = password.HashPassword(user, "123456");
        user.PasswordHash = hashed;
        var userStore = new UserStore<User>(context);
    
        await userStore.CreateAsync(user);
        await EnsureRole(serviceProvider, user.Email, roles);
        await context.SaveChangesAsync();
    }
