    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();
    }
    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        app.UseMvc();
        app.Run(async (context) =>
        {
            await context.Response.WriteAsync("Hello World!");
        });         
    }
