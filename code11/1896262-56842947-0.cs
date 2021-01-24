                    AuthenticationType = "OpenIdConnect",
                    Authority = OIDC_baseUrl,
                    ClientId = clientId,
                    ClientSecret = clientSecret,
                    RedirectUri = redirectUri,
                    ResponseType = "code id_token",
                    Scope = "openid",
           		    **CallbackPath = '/appName/',**
                    Notifications = new OpenIdConnectAuthenticationNotifications
                    {
                        AuthorizationCodeReceived = async (context) =>
                        {
                            await GetAccessTokenAndStoreWithIdentity(context);
                        }
                    }
                }
