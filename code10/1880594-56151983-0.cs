services.AddIdentity<ApplicationUser, IdentityRole>()
 .AddEntityFrameworkStores<ApplicationDbContext>()
 .AddDefaultTokenProviders();
 2. Create Role and Assign User for Role
private async Task CreateUserRoles(IServiceProvider serviceProvider)
{
 var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
 var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
  
 IdentityResult roleResult;
 //Adding Admin Role
 var roleCheck = await RoleManager.RoleExistsAsync("Admin");
 if (!roleCheck)
 {
 //create the roles and seed them to the database
 roleResult = await RoleManager.CreateAsync(new IdentityRole("Admin"));
 }
 //Assign Admin role to the main User here we have given our newly registered 
 //login id for Admin management
 ApplicationUser user = await UserManager.FindByEmailAsync("syedshanumcain@gmail.com");
 var User = new ApplicationUser();
 await UserManager.AddToRoleAsync(user, "Admin");
}
