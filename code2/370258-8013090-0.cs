    routes.MapRoute(
        "GetUserFavorites", // Route name
        "users/{id}/favorites",  // URL with parameters
        new { controller = "Users", action = "GetUserFavorites" },  // Parameter defaults
        new { id = @"\d+" } // Route constraint
    );
    routes.MapRoute(
        "GetUser", // Route name
        "users/{id}",  // URL with parameters
        new { controller = "Users", action = "GetUser" }  // Parameter defaults
        new { id = @"\d+" } // Route constraint
    );
    routes.MapRoute(
        "GetAllUsers", // Route name
        "users",  // URL with parameters
        new { controller = "Users", action = "GetAllUsers" }  // Parameter defaults
    );
