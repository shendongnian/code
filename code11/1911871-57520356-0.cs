    using System;
    using System.Configuration;
    using System.Threading.Tasks;
    using Microsoft.Owin;
    using Owin;
    using Microsoft.IdentityModel.Protocols;
    using Microsoft.Owin.Security;
    using Microsoft.Owin.Security.Cookies;
    using Microsoft.Owin.Security.OpenIdConnect;
    using Microsoft.Owin.Security.Notifications;
    using System.IdentityModel.Claims;
    using ToDoGraphDemo.TokenStorage;
    using System.Web;
    using Microsoft.Identity.Client;
    
    [assembly: OwinStartup(typeof(ToDoGraphDemo.Startup))]
    
    namespace ToDoGraphDemo
    {
        public class Startup
        {
            // The Client ID is used by the application to uniquely identify itself to Azure AD.
            string clientId = ConfigurationManager.AppSettings["ClientId"];
            // RedirectUri is the URL where the user will be redirected to after they sign in.
            string redirectUri = ConfigurationManager.AppSettings["RedirectUri"];
            // Tenant is the tenant ID (e.g. contoso.onmicrosoft.com, or 'common' for multi-tenant)
            static string tenant = ConfigurationManager.AppSettings["Tenant"];
            // Authority is the URL for authority, composed by Azure Active Directory v2 endpoint 
            // and the tenant name (e.g. https://login.microsoftonline.com/contoso.onmicrosoft.com/v2.0)
            string authority = String.Format(System.Globalization.CultureInfo.InvariantCulture, 
                ConfigurationManager.AppSettings["Authority"], tenant);
            // Scopes are the specific permissions we are requesting for the application.
            string scopes = ConfigurationManager.AppSettings["Scopes"];
            // ClientSecret is a password associated with the application in the authority. 
            // It is used to obtain an access token for the user on server-side apps.
            string clientSecret = ConfigurationManager.AppSettings["ClientSecret"];
    
            /// <summary>
            /// Configure OWIN to use OpenIdConnect
            /// </summary>
            /// <param name="app"></param>
            public void Configuration(IAppBuilder app)
            {
                app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);
    
                app.UseCookieAuthentication(new CookieAuthenticationOptions());
                app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
                {
                    ClientId = clientId,
                    Authority = authority,
                    RedirectUri = redirectUri,
                    PostLogoutRedirectUri = redirectUri,
                    Scope = "openid email profile offline_access " + scopes,
    
                    // TokenValidationParameters allows you to control the users who are allowed to sign in
                    // to your application. In this demo we only allow users associated with the specified tenant. 
                    // If ValidateIssuer is set to false, anybody with a personal or work Microsoft account can 
                    // sign in.
                    TokenValidationParameters = new System.IdentityModel.Tokens.TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidIssuer = tenant
                    },
    
                    // OpenIdConnect event handlers/callbacks.
                    Notifications = new OpenIdConnectAuthenticationNotifications
                    {
                        AuthorizationCodeReceived = OnAuthorizationCodeReceived,
                        AuthenticationFailed = OnAuthenticationFailed
                    }
                });
            }
    
            /// <summary>
            /// Handle authorization codes by creating a token cache then requesting and storing an access token
            /// for the user.
            /// </summary>
            /// <param name="context"></param>
            /// <returns></returns>
            private async Task OnAuthorizationCodeReceived(AuthorizationCodeReceivedNotification context)
            {
                string userId = context.AuthenticationTicket.Identity.FindFirst(ClaimTypes.NameIdentifier).Value;
                TokenCache userTokenCache = new SessionTokenCache(
                    userId, context.OwinContext.Environment["System.Web.HttpContextBase"] as HttpContextBase).GetMsalCacheInstance();
                // A ConfidentialClientApplication is a server-side client application that can securely store a client secret,
                // which is not accessible by the user.
                ConfidentialClientApplication cca = new ConfidentialClientApplication(
                    clientId, redirectUri, new ClientCredential(clientSecret), userTokenCache, null);
                string[] scopes = this.scopes.Split(new char[] { ' ' });
    
                AuthenticationResult result = await cca.AcquireTokenByAuthorizationCodeAsync(context.Code, scopes);
                var accessToken = result.AccessToken;
            }
    
            /// <summary>
            /// Handle failed authentication requests by redirecting the user to the home page with an error in the query string.
            /// </summary>
            /// <param name="context"></param>
            /// <returns></returns>
            private Task OnAuthenticationFailed(AuthenticationFailedNotification<OpenIdConnectMessage, OpenIdConnectAuthenticationOptions> context)
            {
                context.HandleResponse();
                context.Response.Redirect("/?errormessage=" + context.Exception.Message);
                return Task.FromResult(0);
            }
        }
    }
