    services.AddAuthorization(options =>
            {
                options.AddPolicy("UserCheck", policy =>
                {
                    policy.RequireAssertion(context =>
                    {
                        var path = ((PageActionDescriptor)((ActionContext)context.Resource).ActionDescriptor).RelativePath;
                        if (path.StartsWith("/Pages")
                        && context.User.HasClaim("Type", UserType.Administrator.ToString()))
                        {
                            return true;
                        }
                        else if(path.StartsWith("/Pages/Admin/User")
                        && context.User.HasClaim(c => c.Type == "Type"))
                        {
                            return true;
                        }
                        return false;
                    });
                });
            });
    services.AddMvc()
                .AddRazorPagesOptions(options =>
                {
                   //options.Conventions.AuthorizeFolder("/Admin/User", "UserCheck");
                    options.Conventions.AuthorizeFolder("/Admin", "UserCheck");
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
