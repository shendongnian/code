    public virtual async Task SignInAsync(TUser user, AuthenticationProperties authenticationProperties, string authenticationMethod = null)
    {
        var userPrincipal = await CreateUserPrincipalAsync(user);
        // Review: should we guard against CreateUserPrincipal returning null?
        if (authenticationMethod != null)
        {
            userPrincipal.Identities.First().AddClaim(new Claim(ClaimTypes.AuthenticationMethod, authenticationMethod));
        }
        await Context.SignInAsync(IdentityConstants.ApplicationScheme,
            userPrincipal,
            authenticationProperties ?? new AuthenticationProperties());
    }
