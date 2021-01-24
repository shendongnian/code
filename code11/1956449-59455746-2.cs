    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        app.UseCors("Any");
        // The others middlewares.
        if (env.IsDevelopment())
        {
            app.UseSpa(spa =>
            {
                spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
            });
        }
    }
