    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        app.Use(async (context, next) =>
        {
            await next.Invoke();
            // Do logging or other work that doesn't write to the Response.
        });
        
        // The others middlewares.
    }
