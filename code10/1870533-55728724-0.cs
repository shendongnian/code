    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        app.UsePathBase(new PathString("/EndpointA"));
        app.UseMvc();
    }
