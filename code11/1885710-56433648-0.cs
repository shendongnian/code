    namespace MyNamespace.Services
    {
        
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
                    new Claim(CustomClaimTypes.TenantId, user.TenantId.ToString()),
                };
    
                context.IssuedClaims.AddRange(claims);
            }
    
            public async Task IsActiveAsync(IsActiveContext context)
            {
                var user = await _userManager.GetUserAsync(context.Subject);
    
                context.IsActive = (user != null) && user.IsActive;
            }
        }
    
    }
