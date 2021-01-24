class JWTAuthenticationStateProvider : AuthenticationStateProvider
{
    private bool IsLogedIn = false;
    private CustomCredentials credentials = null;
    // private ClaimsPrincipal currentClaimsPrincipal = null; (optinally)
    public Task Login( string user, string password )
    {
         credentials = go_backend_login_service( user, password );
         // do stuff with credentials and claims
         // I raise event here to notify login
         keepSession( );
    }
    public Task Logout(  )
    {
         go_bakcend_logout_service( credentials );
         // do stuff with claims
         IsLogedIn = false;
         // I raise event here to notify logout
    }
    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        // make a response from credentials or currentClaimsPrincipal
    }
    private async void KeepSession()
    {
        while(IsLogedIn)
        {
            credentials = go_backend_renewingJWT_service( credentials );
            // do stuff with new credentials: check are ok, update IsLogedIn, ...
            // I raise event here if server says logout
            await Task.Delay(1000);  // sleep for a while.
        }
    }
}
Remember to register component by DI:
public void ConfigureServices(IServiceCollection services)
{
    // ... other services added here ...
    // One JWTAuthenticationStateProvider for each connection:
    services.AddScoped<AuthenticationStateProvider, 
                       JWTAuthenticationStateProvider>();
}
More about Authentication and Authorization on [github SteveSandersonMS/blazor-auth.md][1]
  [1]: https://gist.github.com/SteveSandersonMS/175a08dcdccb384a52ba760122cd2eda
