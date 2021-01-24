    public class CustomProfileService : IProfileService
    {
        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            context.IssuedClaims.Add(new Claim("MyName", "Ophir"));
            return Task.FromResult(0);
        }
    
        public Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;    
            return Task.FromResult(0);
        }
    }
