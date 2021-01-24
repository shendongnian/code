    public void ConfigureServices(IServiceCollection services)
    {
        services.AddResponseCaching();
        services.AddMvc()
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
    }
    
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
        }
    
        app.UseStaticFiles();
    
        app.UseResponseCaching();
    
        app.Use(async (context, next) =>
        {
            context.Response.GetTypedHeaders().CacheControl = 
                new Microsoft.Net.Http.Headers.CacheControlHeaderValue()
                {
                    Public = true,
                    MaxAge = TimeSpan.FromSeconds(10)
                };
            context.Response.Headers[Microsoft.Net.Http.Headers.HeaderNames.Vary] = 
                new string[] { "Accept-Encoding" };
    
            await next();
        });
    
        app.UseMvc();
    }
