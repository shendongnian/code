    public static void RegisterRoutes(RouteCollection routes)
    {
        AreaRegistration.RegisterAllAreas();
                
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
    
        routes.MapRoute(
            "Products",
            "products/show/{name}",
                new {controller = "Products", action = "Show", name = UrlParameter.Optional}
            );
    
        ...
    }     
   
