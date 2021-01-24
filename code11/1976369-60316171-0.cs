csharp
public class CustomUserStore : IUserStore<IdentityUser>,
                               IUserClaimStore<IdentityUser>,
                               IUserLoginStore<IdentityUser>,
                               IUserRoleStore<IdentityUser>,
                               IUserPasswordStore<IdentityUser>,
                               IUserSecurityStampStore<IdentityUser>
{
    // interface implementations not shown
}
And then inject it :
csharp
public void ConfigureServices(IServiceCollection services)
{
    // Add identity types
    services.AddIdentity<ApplicationUser, ApplicationRole>()
        .AddDefaultTokenProviders();
    // Identity Services
    services.AddTransient<IUserStore<ApplicationUser>, CustomUserStore>();
    string connectionString = Configuration.GetConnectionString("DefaultConnection");
    services.AddTransient<SqlConnection>(e => new SqlConnection(connectionString));
    services.AddTransient<DapperUsersTable>();
    // additional configuration
}
It is documented in [the official documentation](https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity-custom-storage-providers?view=aspnetcore-3.1).
