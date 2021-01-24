public JwtSecurityToken Validate(string token)
        {
            string stsDiscoveryEndpoint = "https://login.microsoftonline.com/common/v2.0/.well-known/openid-configuration";
            ConfigurationManager<OpenIdConnectConfiguration> configManager = new ConfigurationManager<OpenIdConnectConfiguration>(stsDiscoveryEndpoint, new OpenIdConnectConfigurationRetriever());
            OpenIdConnectConfiguration config = configManager.GetConfigurationAsync().Result;
            TokenValidationParameters validationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                IssuerSigningKeys = config.SigningKeys,
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
        public void Configuration(IAppBuilder app)
        {
            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);
            app.UseCookieAuthentication(new CookieAuthenticationOptions());
            app.UseOpenIdConnectAuthentication(
                new OpenIdConnectAuthenticationOptions
                {
                    // Sets the ClientId, authority, RedirectUr,ClientSecret as obtained from web.config
                    ClientId = clientId,
                    ClientSecret = clientSecret,
                    Authority = authority,
                    RedirectUri = redirectUri,
                    // PostLogoutRedirectUri is the page that users will be redirected to after sign-out. In this case, it is using the home page
                    PostLogoutRedirectUri = redirectUri,
                    Scope = OpenIdConnectScope.OpenIdProfile,
                    // ResponseType is set to request the id_token - which contains basic information about the signed-in user
                    ResponseType = OpenIdConnectResponseType.CodeIdToken,
                    // ValidateIssuer set to false to allow personal and work accounts from any organization to sign in to your application
                    // To only allow users from a single organizations, set ValidateIssuer to true and 'tenant' setting in web.config to the tenant name
                    // To allow users from only a list of specific organizations, set ValidateIssuer to true and use ValidIssuers parameter
                    TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = false // This is a simplification
                    },
                    // OpenIdConnectAuthenticationNotifications configures OWIN to send notification of failed authentications to OnAuthenticationFailed method
                    Notifications = new OpenIdConnectAuthenticationNotifications
                    {
                        AuthenticationFailed = OnAuthenticationFailed,
                        AuthorizationCodeReceived = OnAuthorizationCodeReceived
                    }
                }
            ); ;
        }
       
        private Task OnAuthenticationFailed(AuthenticationFailedNotification<OpenIdConnectMessage, OpenIdConnectAuthenticationOptions> context)
        {
            context.HandleResponse();
            context.Response.Redirect("/?errormessage=" + context.Exception.Message);
            return Task.FromResult(0);
        }
        private async Task OnAuthorizationCodeReceived(AuthorizationCodeReceivedNotification notification)
        {
            var idClient = ConfidentialClientApplicationBuilder.Create(clientId)
                .WithRedirectUri(redirectUri)
                .WithClientSecret(clientSecret)
                .Build();
                string[] scopes = { };
                var result = await idClient.AcquireTokenByAuthorizationCode(
                    scopes, notification.Code).ExecuteAsync();
                 
                var token = result.AccessToken;
        }
Package.config file :
<?xml version="1.0" encoding="utf-8"?>
<packages>
  <package id="Antlr" version="3.5.0.2" targetFramework="net472" />
  <package id="bootstrap" version="3.4.1" targetFramework="net472" />
  <package id="jQuery" version="3.3.1" targetFramework="net472" />
  <package id="jQuery.Validation" version="1.17.0" targetFramework="net472" />
  <package id="Microsoft.AspNet.Mvc" version="5.2.7" targetFramework="net472" />
  <package id="Microsoft.AspNet.Razor" version="3.2.7" targetFramework="net472" />
  <package id="Microsoft.AspNet.Web.Optimization" version="1.1.3" targetFramework="net472" />
  <package id="Microsoft.AspNet.WebPages" version="3.2.7" targetFramework="net472" />
  <package id="Microsoft.CodeDom.Providers.DotNetCompilerPlatform" version="2.0.0" targetFramework="net472" />
  <package id="Microsoft.Identity.Client" version="4.3.0" targetFramework="net472" />
  <package id="Microsoft.IdentityModel.JsonWebTokens" version="5.3.0" targetFramework="net472" />
  <package id="Microsoft.IdentityModel.Logging" version="5.3.0" targetFramework="net472" />
  <package id="Microsoft.IdentityModel.Protocols" version="5.3.0" targetFramework="net472" />
  <package id="Microsoft.IdentityModel.Protocols.OpenIdConnect" version="5.3.0" targetFramework="net472" />
  <package id="Microsoft.IdentityModel.Tokens" version="5.3.0" targetFramework="net472" />
  <package id="Microsoft.jQuery.Unobtrusive.Validation" version="3.2.11" targetFramework="net472" />
  <package id="Microsoft.Owin" version="4.0.1" targetFramework="net472" />
  <package id="Microsoft.Owin.Host.SystemWeb" version="4.0.1" targetFramework="net472" />
  <package id="Microsoft.Owin.Security" version="4.0.1" targetFramework="net472" />
  <package id="Microsoft.Owin.Security.Cookies" version="4.0.1" targetFramework="net472" />
  <package id="Microsoft.Owin.Security.OpenIdConnect" version="4.0.1" targetFramework="net472" />
  <package id="Microsoft.Web.Infrastructure" version="1.0.0.0" targetFramework="net472" />
  <package id="Modernizr" version="2.8.3" targetFramework="net472" />
  <package id="Newtonsoft.Json" version="11.0.1" targetFramework="net472" />
  <package id="Owin" version="1.0" targetFramework="net472" />
  <package id="System.IdentityModel.Tokens.Jwt" version="5.3.0" targetFramework="net472" />
  <package id="WebGrease" version="1.6.0" targetFramework="net472" />
</packages>
For more deatils, please refer to the [blog][1].
  [1]: https://www.jerriepelser.com/blog/manually-validating-rs256-jwt-dotnet/
