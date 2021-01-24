    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseRouter(routeBuilder => {
               
                var template = "{controller=Users}/{action=GetAll}/{id?}";
                routeBuilder.MapMiddlewareRoute(template, appBuilder => {
                    appBuilder.UseAuthentication();
                    appBuilder.UseMvc();
                });
            });
           
            //add more middlewares if you want other routes
            app.UseAuthentication();
            
            app.UseMvc();
        }
