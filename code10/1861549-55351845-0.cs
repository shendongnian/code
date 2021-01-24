           public void ConfigureServices(IServiceCollection services)
           {
             services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
             services.AddOData(); //This Is added for OData
           }
         public void Configure(IApplicationBuilder app, IHostingEnvironment env)
         {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseMvc(routeBuilder =>
            {
                routeBuilder.EnableDependencyInjection(); //This Is added for OData
                routeBuilder.Expand().Select().Count().OrderBy().Filter(); //This Is added for OData
            });
        }
