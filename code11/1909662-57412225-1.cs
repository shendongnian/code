     public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
            {
               
                app.UseCors("AllowAllHeaders");
               
                           app.UseMiddleware<AuthenticationMiddleware>();
                app.UseHttpsRedirection();
                app.UseMvc();
            }
