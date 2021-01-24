        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider service, ILoggerFactory loggerFactory)
        {
            app.UseMiddleware<GCMiddleware>();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseStaticFiles();
            //app.UseHttpsRedirection();
            app.UseMvcWithDefaultRoute();
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("\"No ");
            });
        }
