    public void Configure(IApplicationBuilder app)
    {
        app.UseStaticFiles(); // For the wwwroot folder
    
        //OR
        app.UseStaticFiles(new StaticFileOptions
        {
            FileProvider = new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), "MyStaticFiles")),
            RequestPath = "/StaticFiles"
        });
    }
