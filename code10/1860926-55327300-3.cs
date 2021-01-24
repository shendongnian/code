    public class Startup
    {      
        public void ConfigureOAuth(IAppBuilder app)
        {
            AuthenticationTokenProvider authTokenProvider = new AuthenticationTokenProvider();
            authTokenProvider.OnCreate = (context) =>
            {               
                context.SetToken(TokenService.GenerateToken());
            };
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,                              
                Provider = new SimpleAuthorizationServerProvider(),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(TokenService.expireTime),
                AccessTokenProvider = authTokenProvider,
                AuthorizationCodeProvider = authTokenProvider
            };
            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            ConfigureOAuth(app);            
        }
    }
