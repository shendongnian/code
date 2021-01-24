public class ProfileService : IProfileService
{
    protected UserManager<ApplicationUser> _userManager;
    public ProfileService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }
    public async Task GetProfileDataAsync(ProfileDataRequestContext context)
    {         
        var user = await _userManager.GetUserAsync(context.Subject);
        var claims = new List<Claim>
        {
            new Claim("my_FirstName", "user_FirstName"),
            new Claim("my_LastName", "user_LastName")
        };
        context.IssuedClaims.AddRange(claims);
    }
    public async Task IsActiveAsync(IsActiveContext context)
    {            
        var user = await _userManager.GetUserAsync(context.Subject);
        context.IsActive = (user != null);
    }
}
the Startup.cs file
services.AddIdentityServer()
        .AddApiAuthorization<ApplicationUser, ApplicationDbContext>()
        .AddProfileService<ProfileService>();
With that, **now the JWT contains my custom claims**.  
I am not sure why the override for `UserClaimsPrincipalFactory` was not able to solve that.  
Will try to study deeper those areas.
