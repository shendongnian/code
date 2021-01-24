    public void Configure(IApplicationBuilder app)
    {
        app.UseStaticFiles(); // For the wwwroot folder
        app.UseStaticFiles(new StaticFileOptions
        {
            FileProvider = new PhysicalFileProvider(
                "X:\game_data\avatars\"),
            RequestPath = "/avatars"
        });
    }
