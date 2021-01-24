if (context.Request.Path.Value.StartsWith("/api"))
    
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
    
            app.Use(async (context, next) =>
            {
                if (context.Request.Path.Value.StartsWith("/api"))
                {
                    await context.Response.WriteAsync("Hello");
                }
            });
            app.UseMvc();
        }
