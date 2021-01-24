    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        //...
        //Configure the app to serve static files and enable default file mapping. 
        app.UseDefaultFiles();
        app.UseStaticFiles();
        app.UseHttpsRedirection();
        app.UseMvc();
    }
