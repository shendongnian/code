    services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    // Adds a cookie for the browser to remember
                    .AddCookie(options =>
                    {
                        options.LoginPath = "/signin";
                        options.LogoutPath = "/signout";
                        options.AccessDeniedPath = "/forbidden";
                        options.SlidingExpiration = true;
                        options.Events = new CookieAuthenticationEvents()
                        {
                            OnRedirectToLogin = op =>
                            {
                                if (op.Request.Query["so"].Count == 0)
                                    op.HttpContext.Session.SetString("RedirectToLogin", true.ToString());
                            op.Response.Redirect(op.RedirectUri);
                            return Task.FromResult(0);
                        }
                    };
                });
