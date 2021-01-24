    app.UseSpa(spa =>
        {
            spa.Options.SourcePath = "ClientApp";
    
            if (env.IsDevelopment())
            {
                spa.Options.StartupTimeout = new TimeSpan(0, 0, 80); // 80 seconds
                spa.UseAngularCliServer(npmScript: "start");
            }
        });
