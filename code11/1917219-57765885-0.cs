    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        var options = new RewriteOptions()
        .AddRedirect(@"^$", $"{LocalizationRouteDataHandler.DefaultCulture}/{LocalizationRouteDataHandler.DefaultController}");           
        app.UseRewriter(options);
        var localizationOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
        app.UseRequestLocalization(localizationOptions.Value);            
        //rest code
        app.UseMvc(routes =>
        {
            routes.MapRoute(
                name: "default",
                template: "{controller=Home}/{action=Index}/{id?}",
                defaults: new { culture = LocalizationRouteDataHandler.DefaultCulture }
            );
        });
    }
