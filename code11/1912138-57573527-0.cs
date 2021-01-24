        services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
            .AddRazorPagesOptions(options =>
        {
            options.AllowAreas = true; //--working after add this line
            options.Conventions.AddAreaPageRoute("Identity", "/Account/Login", "");
        });
