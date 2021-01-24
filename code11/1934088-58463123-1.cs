    public void ConfigureServices(IServiceCollection services)
            {
                services.Configure(options =>
                {
                    options.CheckConsentNeeded = context => true;
                    options.MinimumSameSitePolicy = SameSiteMode.None;
                });
     
    services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
                services.AddSignalR();
            }
     
            public void Configure(IApplicationBuilder app, IHostingEnvironment env)
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }
                else
                {
                    app.UseExceptionHandler("/Home/Error");
                }
     
                app.UseStaticFiles();
                app.UseCookiePolicy();
                app.UseSignalR(routes =>
                {
                    routes.MapHub<ConnectionHub>("/connectionHub");
                });
                app.UseMvc(routes =>
                {
                    routes.MapRoute(
                        name: "default",
                        template: "{controller=Home}/{action=Index}/{id?}");
                });
            }
