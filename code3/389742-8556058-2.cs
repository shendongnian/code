    routes.MapRoute(
      "Admin Controller Routes", // Route name
      "admin/{action}/{id}", // URL with parameters
      new { controller = "Admin", id = UrlParameter.Optional } // Parameter defaults
    );
    
    routes.MapRoute(
      "Account Controller Routes", // Route name
      "account/{action}/{id}", // URL with parameters
      new { controller = "Account", id = UrlParameter.Optional } // Parameter defaults
    );
    
    ... etc - one for each controller ...
