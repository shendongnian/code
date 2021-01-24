    public void ConfigureServices(IServiceCollection services)
    {
        // snip
  
        services.AddMvc()
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
            .AddSessionStateTempDataProvider();
    
        services.AddSession();
    }
    
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        // snip
    
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseCookiePolicy();
        app.UseSession();
        app.UseMvc();
    }
