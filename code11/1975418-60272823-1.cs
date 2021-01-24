    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePagesWithReExecute("/Status/{0}");
            app.UseExceptionHandler("/Status");
        }
        else
        {                
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePagesWithReExecute("/Status/{0}");
            app.UseExceptionHandler("/Status");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapRazorPages();
        });
    }
