    public void ConfigureServices(IServiceCollection services) {
      services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options => 
        {
          options.LoginPath = "/Login/Index";
        });
    }
    
    public void Configure(IApplicationBuilder app) {
      // Add it but BEFORE app.UseEndpoints(..);
      app.UseAuthentication();
    }
