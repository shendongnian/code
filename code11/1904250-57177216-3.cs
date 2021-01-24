    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
            {
                if (env.IsDevelopment())
                {
                    app.UseBrowserLink();
                    app.UseDeveloperExceptionPage();
                }
                else
                {
                    app.UseExceptionHandler("/Home/Error");
                }
                app.UseCors("CorsPolicy");
                app.UseStaticFiles();
    
                app.UseSignalR(route =>
                {
                    route.MapHub<NotificationHub>("/notificationHub"); // name of js file
                });
    
                app.UseMvc(routes =>
                {
                    routes.MapRoute(
                        name: "default",
                        template: "{controller=Home}/{action=Index}/{id?}");
                });
            }
        enter code here
