    services.AddMvc()
            .AddRazorPagesOptions(options => {
                    options.Conventions.AddAreaPageRoute("Identity", "/Account/Login", "");
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
