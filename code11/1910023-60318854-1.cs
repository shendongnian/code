    public void ConfigureServices(IServiceCollection services)
        {
           
           //Other Configurations
            services.AddIdentity<User, Role>(
                options =>
                {
                    options.SignIn.RequireConfirmedEmail = true;
                    options.Lockout.AllowedForNewUsers = true;
                    options.Lockout.MaxFailedAccessAttempts = 3;
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
                }
                ).AddDefaultTokenProviders();
        }
