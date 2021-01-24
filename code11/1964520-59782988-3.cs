    public void Configure(IApplicationBuilder app, IHostingEnvironment env,    ILoggerFactory loggerFactory)
    {
    app.UseStaticFiles(); // For the wwwroot folder
    app.UseStaticFiles(new StaticFileOptions()
    {
        FileProvider = new PhysicalFileProvider(
            Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images")),
        RequestPath = new PathString("/MyImages")
    });
    app.UseDirectoryBrowser(new DirectoryBrowserOptions()
    {
        FileProvider = new PhysicalFileProvider(
            Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images")),
        RequestPath = new PathString("/MyImages")
    });
    }
