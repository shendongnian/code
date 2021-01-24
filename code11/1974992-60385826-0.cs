    public void ConfigureServices(IServiceCollection services)
            {
                 services.AddIdentity<AppUser, IdentityRole>(opts => {
                    opts.User.RequireUniqueEmail = true;
                    opts.User.AllowedUserNameCharacters = null; //disable validation
                    opts.Password.RequiredLength = 8;
                    opts.Password.RequireNonAlphanumeric = false;
                    opts.Password.RequireLowercase = false;
                    opts.Password.RequireUppercase = false;
                    opts.Password.RequireDigit = true;
                })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
                .Services.ConfigureApplicationCookie(options =>
                {
                    //previous cookies not valid
                    options.SlidingExpiration = true;
                    options.ExpireTimeSpan = TimeSpan.FromDays(1);
                });
                services.AddMvc(options =>
                {
                    options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
                    options.Filters.Add<AuditUserActionFilter>();
                });
    
                (...)
            }
    
            public void Configure(IApplicationBuilder app, IHostingEnvironment env, IAntiforgery antiforgery)
            {
                app.UseAuthentication();
    
                (...)
            }
        }
