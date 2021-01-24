    public class CustomPasswordValidator : IPasswordValidator<AppUser>
    {
        public async Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user, string password)
        {
            // ...
        }
    }
