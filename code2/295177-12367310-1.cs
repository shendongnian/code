     routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
       // for Old url 
       routes.MapRoute(
            "Results",
            "{city}-{state}/{searchTerm}",
            new { controller = "Results", action = "Search" }
        );
    // For Default Url 
   
     routes.MapRoute(
            "Default", // Route name
            "{controller}/{action}/{id}", // URL with parameters
            new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
        );
