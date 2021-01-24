 ...
 app.UseMvc(...)
 app.Map("/admin",
   adminApp =>
   {
     adminApp.UseSpa(spa =>
     {
       spa.Options.SourcePath = "angular/admin";
       spa.Options.DefaultPageStaticFileOptions = new StaticFileOptions
       {
           FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "angular", "admin"))
       };
       if (env.IsDevelopment())
         spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
      });
    });
  app.Map("/user",
    userApp =>
    {
      userApp.UseSpa(spa =>
      {
        spa.Options.SourcePath = "angular/user";
        spa.Options.DefaultPageStaticFileOptions = new StaticFileOptions
        {
            FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "angular", "user"))
        };
        if (env.IsDevelopment())
          spa.UseProxyToSpaDevelopmentServer("http://localhost:4201");
      });
  });  
                ```
