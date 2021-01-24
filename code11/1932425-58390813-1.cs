var user = await userManager.FindByNameAsync(UserName);
<b>var valid= await signInManager.UserManager.CheckPasswordAsync(user, Password);</b>
if (valid)
{
    <b>var principal = await signInManager.CreateUserPrincipalAsync(user);
    signInManager.Context.User = principal;</b>
    
    // if you check the authentication state now, you'll find you've signed in :
    // var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
    
    successMessage = $"{UserName}, signed in.";
    errorMessage = "";
}
else
{
    successMessage = "";
    errorMessage = "Username or password is incorrect.";
}
