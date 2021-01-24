    app.UseSpa(spa =>
        {
            spa.Options.SourcePath = "client";
            if (env.IsDevelopment())
            {
                spa.UseReactDevelopmentServer(npmScript: "start");
            }
        });
