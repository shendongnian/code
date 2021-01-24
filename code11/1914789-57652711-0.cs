public JwtSecurityToken Validate(string token)
 {
     string stsDiscoveryEndpoint = "https://login.microsoftonline.com/common/v2.0/.well-known/openid-configuration";
     ConfigurationManager<OpenIdConnectConfiguration> configManager = new ConfigurationManager<OpenIdConnectConfiguration>(stsDiscoveryEndpoint);
     OpenIdConnectConfiguration config = configManager.GetConfigurationAsync().Result;
     TokenValidationParameters validationParameters = new TokenValidationParameters
     {
         ValidateAudience = false,
         ValidateIssuer = false,
         IssuerSigningTokens = config.SigningTokens,
         ValidateLifetime = false
     };
     JwtSecurityTokenHandler tokendHandler = new JwtSecurityTokenHandler();
     SecurityToken jwt;
     var result = tokendHandler.ValidateToken(token, validationParameters, out jwt);
     return jwt as JwtSecurityToken;
 }
On startup.cs
 public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);
            app.UseCookieAuthentication(new CookieAuthenticationOptions());
            // Custom middleware initialization. This is activated when the code obtained from a code_grant is present in the querystring (&code=<code>).
            app.UseOAuth2CodeRedeemer(
                new OAuth2CodeRedeemerOptions
                {
                    ClientId = AuthenticationConfig.ClientId,
                    ClientSecret = AuthenticationConfig.ClientSecret,
                    RedirectUri = AuthenticationConfig.RedirectUri
                }
                );
            app.UseOpenIdConnectAuthentication(
                new OpenIdConnectAuthenticationOptions
                {
                    // The `Authority` represents the v2.0 endpoint - https://login.microsoftonline.com/common/v2.0
                    Authority = AuthenticationConfig.Authority,
                    ClientId = AuthenticationConfig.ClientId,
                    RedirectUri = AuthenticationConfig.RedirectUri,
                    PostLogoutRedirectUri = AuthenticationConfig.RedirectUri,
                    Scope = "openid email profile offline_access "  + " Mail.Read",
                    TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
        
                    },
                    Notifications = new OpenIdConnectAuthenticationNotifications()
                    {
                        AuthorizationCodeReceived = OnAuthorizationCodeReceived,
                        AuthenticationFailed = OnAuthenticationFailed,
                    }
                });
        }
        private async Task OnAuthorizationCodeReceived(AuthorizationCodeReceivedNotification context)
        {
            // Upon successful sign in, get the access token & cache it using MSAL
            IConfidentialClientApplication clientApp = MsalAppBuilder.BuildConfidentialClientApplication(new ClaimsPrincipal(context.AuthenticationTicket.Identity));
            AuthenticationResult result = await clientApp.AcquireTokenByAuthorizationCode(new[] { "Mail.Read" }, context.Code).ExecuteAsync();
        }
        private Task OnAuthenticationFailed(AuthenticationFailedNotification<OpenIdConnectMessage, OpenIdConnectAuthenticationOptions> notification)
        {
            notification.HandleResponse();
            notification.Response.Redirect("/Error?message=" + notification.Exception.Message);
            return Task.FromResult(0);
        }
    }
For more deatils, please refer to the [blog][1].
  [1]: https://blogs.msdn.microsoft.com/practice-sharing/2016/03/22/office-365-dev-how-to-validate-the-access-token-issued-by-microsoft-azure-ad/
