    public void ConfigureServices(IServiceCollection services) {
      services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        // What kind of authentication you use? Here I just assume cookie authentication.
        .AddCookie(options => 
        {
          options.LoginPath = "/Login/Index";
        });
    }
    
    public void Configure(IApplicationBuilder app) {
      // Add it but BEFORE app.UseEndpoints(..);
      app.UseAuthentication();
    }
