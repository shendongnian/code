SecurityTokenValidated = context =>
                        {
                            context.AuthenticationTicket.Properties.AllowRefresh = true;
                            context.AuthenticationTicket.Properties.IsPersistent = true;
                        }
Then in AuthorizationCodeReceived add this to the end:
HttpContext.Current.GetOwinContext().Authentication.SignIn(new AuthenticationProperties
                                    {
                                        ExpiresUtc = DateTimeOffset.UtcNow.AddSeconds(tokenResponse.ExpiresIn),
                                        AllowRefresh = true,
                                        IssuedUtc = DateTime.UtcNow,
                                        IsPersistent = true
                                    }, newIdentity);
Where newIdentity is your claims identity, hope this helps.
