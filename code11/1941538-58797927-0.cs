    public class MyProfileService : IProfileService
    {
        public MyProfileService()
        { }
        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Role, "Admin")
            };
            context.IssuedClaims.AddRange(claims);
            return Task.CompletedTask;
        }
        public Task IsActiveAsync(IsActiveContext context)
        {
            // await base.IsActiveAsync(context);
            return Task.CompletedTask;
        }
    }
