      public void Configuration(IAppBuilder app)
        {
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions
            {
                Provider = new ApplicationOAuthBearerAuthenticationProvider()
            });
            app.Use<AuthenticationResponseMiddleware>();
            var options = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/api/xxxx"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1), 
                Provider = new OwinAuthorisationProvider()
                 
            };
            app.UseOAuthAuthorizationServer(options);
              
        }
