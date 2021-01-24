    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            {
                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                    app.MigrateAndSeedDb(development: true);
                }
                else
                {
                     app.MigrateAndSeedDb(development: false);
                }           
    
                app.UseHttpsRedirection();
     ...
