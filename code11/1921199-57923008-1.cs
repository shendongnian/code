        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
           ...
            services.AddIdentity<IdentityUser, IdentityRole>()
                    .AddEntityFrameworkStores<UserContext>()
                     // Here is missing
                    .AddDefaultTokenProviders();;
        }
