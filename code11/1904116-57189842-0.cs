c#
/// <summary>
/// Signs in the specified <paramref name="user"/>.
/// </summary>
/// <param name="user">The user to sign-in.</param>
/// <param name="authenticationProperties">Properties applied to the login and authentication cookie.</param>
/// <param name="authenticationMethod">Name of the method used to authenticate the user.</param>
/// <returns>The task object representing the asynchronous operation.</returns>
public virtual Task SignInAsync(TUser user, AuthenticationProperties authenticationProperties, string authenticationMethod = null)
{
    var additionalClaims = new List<Claim>();
    if (authenticationMethod != null)
    {
        additionalClaims.Add(new Claim(ClaimTypes.AuthenticationMethod, authenticationMethod));
    }
    return SignInWithClaimsAsync(user, authenticationProperties, additionalClaims);
}
public virtual async Task SignInWithClaimsAsync(TUser user, AuthenticationProperties authenticationProperties, IEnumerable<Claim> additionalClaims)
{
    var userPrincipal = await CreateUserPrincipalAsync(user);
    foreach (var claim in additionalClaims)
    {
        userPrincipal.Identities.First().AddClaim(claim);
    }
    await Context.SignInAsync(IdentityConstants.ApplicationScheme,
        userPrincipal,
        authenticationProperties ?? new AuthenticationProperties());
}
So it just calls `HttpContext.SignInAsync` with some options and add claim under some conditions
