    var builder = new ODataConventionModelBuilder(app.ApplicationServices);
    
    builder.EntitySet<Product>("Products");
    
    
    app.UseMvc(routeBuilder =>
    {
        // and this line to enable OData query option, for example $filter
        routeBuilder.Expand().Select().OrderBy().Filter();
    
        routeBuilder.MapODataServiceRoute("ODataRoute", "api", builder.GetEdmModel());
    
    });
