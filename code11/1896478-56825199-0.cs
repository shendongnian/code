    services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(options =>
            {
                options.LoginPath = "/Identity/Account/Login";
                options.Events.OnRedirectToLogin = ctx =>
                {
                    if (ctx.Request.ContentType != null && ctx.Response.StatusCode == (int) HttpStatusCode.OK)
                    {
                        if (ctx.Request.ContentType.Contains("application/json"))
                        {
                            ctx.Response.StatusCode = (int) HttpStatusCode.Unauthorized;
                        }
                    }
                    else
                    {
                        ctx.Response.Redirect(ctx.RedirectUri);
                    }
                    return Task.CompletedTask;
                };
            });
