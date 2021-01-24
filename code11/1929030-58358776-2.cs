    using OrchardCore.Logging;
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        app.UseStaticFiles();
        app.UseOrchardCore(c => c.UseSerilogTenantNameLoggingMiddleware());
    }
