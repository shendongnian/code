    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        app.UsePathBase("/MyPrefix/");
        if (env.IsDevelopment())
        .......
