    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        ...
        <b>app.UseSession(); </b>
        ... 
    
        app.UseMvc(routes =>
        {
            routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}");
        }); 
     }
