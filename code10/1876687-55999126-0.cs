    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<ImageRewriteCollection>();
        // ...
    }
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        app.UseRewriter(new RewriteOptions().Add(new ImageRewriteRule(app.ApplicationServices.GetService<ImageRewriteCollection>())));
        // ...
    }
