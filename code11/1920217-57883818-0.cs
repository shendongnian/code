public void Configure(IApplicationBuilder app, IHostingEnvironment env)
{
    app.UseMvc(routeBuilder =>
    {
         <b>routeBuilder.MapODataServiceRoute(
            "odata",
            "api",
            GetEdmModel(),
            new DefaultODataBatchHandler()
         );</b>
         routeBuilder.EnableDependencyInjection();        
         routeBuilder.
           Count().
           Filter().
           OrderBy().
           Expand().
           Select().
           MaxTop(null);
         routeBuilder.MapRoute(
            name: "default",
            template: "{controller=Home}/{action=Index}/{id?}"
         );
     });
}
