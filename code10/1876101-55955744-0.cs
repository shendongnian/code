    public virtual async Task RefreshSignInAsync(TUser user)
    {
        var auth = await Context.AuthenticateAsync(IdentityConstants.ApplicationScheme);
        var authenticationMethod = auth?.Principal?.FindFirstValue(ClaimTypes.AuthenticationMethod);
        await SignInAsync(user, auth?.Properties, authenticationMethod);
    }
