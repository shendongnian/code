[Route("api/[controller]")]
public partial class HelmetController: ControllerBase
{
}
**Approach 2**
configure a particular OData routes :
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
This will make the `OData` work on route that starts with `/api`.
Here the `GetEdmModel()` method is where you setup the EDM model:
csharp
private static IEdmModel GetEdmModel()
{
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Helmet>("Helmet")
        .EntityType.Filter().Count().Expand().OrderBy().Page().Select();
}
Note in both situation your controller name should be `HelmetController` instead of `HelmetsController` because you're configuring the Model name as `Helmet` instead of `Helmets`. 
Finally, you can query the `Helmet` as below :
/api/Helmet?$select=name
