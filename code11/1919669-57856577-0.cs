    public class IdentityProfileService : IProfileService
    {
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var sub = context.Subject.GetSubjectId();
            // Call UserManager or any database to get more fields
            var user = await _userManager.FindByIdAsync(sub);
            // Set returned claims (System.Security.Claims.Claim) by setting context.IssuedClaims
            context.IssuedClaims = claims;
        }
        public async Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;
        }
    }
