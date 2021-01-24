     Notifications = new OpenIdConnectAuthenticationNotifications
                    {
                        AuthenticationFailed = OnAuthenticationFailed,
                        SecurityTokenValidated = async (x) =>
                        {
                            var identity = x.AuthenticationTicket.Identity;
                            identity.AddClaim(new Claim("test", "test"));
                            await Task.FromResult(0);
                        }
                     }
