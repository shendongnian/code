public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
    app.UseSpaStaticFiles(new StaticFileOptions
    {
        FileProvider = new PhysicalFileProvider(
            Path.Combine(Directory.GetCurrentDirectory(), "angular/user")),
        RequestPath = new PathString("/user")
    });
    app.UseSpaStaticFiles(new StaticFileOptions
    {
        FileProvider = new PhysicalFileProvider(
            Path.Combine(Directory.GetCurrentDirectory(), "angular/admin")),
        RequestPath = new PathString("/admin")
    });
}
