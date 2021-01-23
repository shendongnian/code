    public void ConfigureAuth(IAppBuilder app)
            {
                app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
    
                // Facebook 
                var facebookOptions = new FacebookAuthenticationOptions
                {
                    AppId = "{get_it_from_dev_console}",
                    AppSecret = "{get_it_from_dev_console}",
                    BackchannelHttpHandler = new FacebookBackChannelHandler(),
                    UserInformationEndpoint = "https://graph.facebook.com/v2.4/me?fields=id,name,email,first_name,last_name,location",
                    Provider = new FacebookAuthenticationProvider
                    {
                        OnAuthenticated = context =>
                        {
                            context.Identity.AddClaim(new Claim("FacebookAccessToken", context.AccessToken)); // user acces token needed for posting on the wall 
                            return Task.FromResult(true);
                        }
                    }
                };
                facebookOptions.Scope.Add("email");
                facebookOptions.Scope.Add("publish_actions"); // permission needed for posting on the wall 
                facebookOptions.Scope.Add("publish_pages"); // permission needed for posting on the page
                app.UseFacebookAuthentication(facebookOptions);
    
                AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.NameIdentifier;
            }
        }
