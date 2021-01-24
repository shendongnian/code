cs
.AddOpenIdConnect("lwa", "LoginWithAmazon", options =>
                {
                    options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
                    options.SignOutScheme = IdentityServerConstants.SignoutScheme;
                    options.Authority = "https://www.amazon.com/";
                    options.ClientId = "amzn1.application-oa2-client.xxxxxxxxxxxxxx";
                    options.ClientSecret = "xxxxxxxxxxxxxxxxx";
                    options.ResponseType = "code";
                    options.ResponseMode = "query";
                    options.SaveTokens = true;
                    options.CallbackPath = "/signin-amazon";
                    options.SignedOutCallbackPath = "/signout-callback-amazon";
                    options.RemoteSignOutPath = "/signout-amazon";
                    options.Scope.Clear();
                    options.Scope.Add("profile");
                    options.GetClaimsFromUserInfoEndpoint = true;
                    var rsa = RSA.Create();
                    var key = new RsaSecurityKey(rsa){KeyId = "1"};
                    var jwtClaims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.IssuedAt, "now"),
                        new Claim(JwtClaimTypes.JwtId, Guid.NewGuid().ToString()),
                        new Claim(JwtClaimTypes.Subject, Guid.NewGuid().ToString())
                    };
                    var jwt = new JwtSecurityToken(
                        "issuer",
                        "audience",
                        jwtClaims,
                        DateTime.UtcNow,
                        DateTime.UtcNow.AddHours(1),
                        new SigningCredentials(key, "RS256"));
                    var handler = new JwtSecurityTokenHandler();
                    handler.OutboundClaimTypeMap.Clear();
                    var token = handler.WriteToken(jwt);
                    options.Configuration = new OpenIdConnectConfiguration
                    {
                        AuthorizationEndpoint = "https://www.amazon.com/ap/oa",
                        TokenEndpoint = "https://api.amazon.com/auth/o2/token",
                        UserInfoEndpoint = "https://api.amazon.com/user/profile"
                    };
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateTokenReplay = false,
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = false,
                        IssuerSigningKey = key
                    };
                    AuthorizationCodeReceivedContext hook = null;
                    options.Events = new OpenIdConnectEvents
                    {
                        OnAuthenticationFailed = async context =>
                        {
                            //context.SkipHandler();
                        },
                        OnAuthorizationCodeReceived = async context => { hook = context; },
                        OnTokenResponseReceived = async context =>
                        {
                            context.TokenEndpointResponse.IdToken = token;
                            hook.TokenEndpointResponse = context.TokenEndpointResponse;
                        },
                        OnUserInformationReceived = async context =>
                        {
                            var user = context.User;
                            var claims = new[]
                            {
                                new Claim(JwtClaimTypes.Subject, user["user_id"].ToString()),
                                new Claim(JwtClaimTypes.Email, user["email"].ToString()),
                                new Claim(JwtClaimTypes.Name, user["name"].ToString())
                            };
                            context.Principal = new ClaimsPrincipal(new ClaimsIdentity(claims));
                            context.Success();
                        }
                    };
                })
  [1]: https://login.amazon.com/website
