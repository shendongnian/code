    public static class UserAndRoleDataInitializer
    {
        public static async Task<IdentityResult> SeedData(UserManager<AppUser> userManager, RoleManager<IdentityRole<Guid>> roleManager)
        {
            await SeedRoles(roleManager);
            await SeedUsers(userManager);
            return IdentityResult.Success;
        }
      
        private static async Task<IdentityResult> SeedRoles(RoleManager<IdentityRole<Guid>> roleManager)
        {                       
            var exists = await roleManager.RoleExistsAsync("Administrator");
            if (!exists)
            {               
                await roleManager.CreateAsync(new IdentityRole<Guid>("Administrator"));
            }
            ...
            return IdentityResult.Success;
        }
        private static async Task<IdentityResult> SeedUsers(UserManager<AppUser> userManager)
        {            
            var usr = await userManager.FindByNameAsync("admin");
            if (usr == null)
            {
                AppUser user = new AppUser
                {
                    UserName = "admin",
                    Email = "gbetsos@yahoo.com",
                    FirstName = "Giorgos",
                    LastName = "Betsos"
                };
                IdentityResult result = await userManager.CreateAsync(user, "P@ssw0rd1!");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Administrator");
                }
            }
            return IdentityResult.Success;
        } 
    }
