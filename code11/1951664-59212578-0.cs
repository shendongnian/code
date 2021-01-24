    public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                options.Filters.Add(new AuthorizeFilter(policy));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => 
                {
                    options.Audience = Configuration["AzureAd:ClientId"];
                    options.Authority = 
                        $"{Configuration["AzureAd:Instance"]}{Configuration["AzureAd:TenantId"]}";
                });
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            ...
            app.UseAuthentication();
            app.UseMvc();
        }
