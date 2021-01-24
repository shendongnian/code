    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        //Add your route here
        routes.MapRoute(
         "GetArticle", 
         "Article/{ArtID}", 
         new { controller = "Article", action = "Article" }
        );
        routes.MapRoute(
            name: "Default",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional}
        );
    }
