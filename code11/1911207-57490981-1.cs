    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      // not here 
      //   app.UseAuthentication();
      //  app.UseAuthorization(); 
        app.UseResponseCompression();
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseBlazorDebugging();
        }
        app.UseCors(_myAllowSpecificOrigins);
        app.UseStaticFiles();
        app.UseClientSideBlazorFiles<Client.Startup>();
        app.UseRouting();
      // but here 
        app.UseAuthentication();
        app.UseAuthorization(); 
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapDefaultControllerRoute();
            endpoints.MapFallbackToClientSideBlazor<Client.Startup>("index.html");
        });
    }
