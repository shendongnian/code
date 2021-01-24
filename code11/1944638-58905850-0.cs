    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
       .
       .
       app.UseMiddleware<UnauthorizedRedirectMiddleware>();
       .
    }
