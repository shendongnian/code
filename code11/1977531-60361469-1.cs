    class UserValidator : IIdentityValidator<User>
    {
        public Task<IdentityResult> ValidateAsync(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Email))
            {
                return Task.FromResult(new IdentityResult(new string[] { "Email is required" }));
            }
            return null;
        }
    }
