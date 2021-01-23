      routes.MapRoute(
        "Date-ByDay", // Route name
        "Date/{year}/{month}/{day}", // URL with parameters
        new { controller = "Date", action = "Index" } // Parameter defaults
      );
      routes.MapRoute(
        "Date-ByMonth", // Route name
        "Date/{year}/{month}", // URL with parameters
        new { controller = "Date", action = "Index", month = UrlParameter.Optional } // Parameter defaults
      );
      routes.MapRoute(
        "Date-ByYear", // Route name
        "Date/{year}", // URL with parameters
        new { controller = "Date", action = "Index", year = UrlParameter.Optional } // Parameter defaults
      );
