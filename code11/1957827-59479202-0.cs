    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
       if (env.IsDevelopment())
       {
        SeedData.Initialize(app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope().ServiceProvider);
           app.UseDeveloperExceptionPage();
       }
        // your code...
    }
