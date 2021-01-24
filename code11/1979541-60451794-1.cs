     public void Configure(IApplicationBuilder app, IHostingEnvironment env)
     {
            //NOTE this line must be above .UseMvc() line.
            app.UseNToastNotify();
            
            app.UseMvc(routes =>
                {
                    routes.MapRoute(
                        name: "default",
                        template: "{controller=Home}/{action=Index}/{id?}");
                });
     }
