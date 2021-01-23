    public static void RegisterRoutes()
    {
        var adminRoutes = new[]
                                {
                                    new [] { "Phones", "PhoneId", "Delete", "DeletePhone" },
                                    // Add the rest of your routes here.
                                };
    
        foreach ( var adminRoute in adminRoutes )
        {
            RegisterAdminRoute( adminRoute[0], adminRoute[1], adminRoute[2], adminRoute[3] );
        }
    }
    
    public static void RegisterAdminRoute( string area, string idName, string actionName, string action )
    {
        RouteTable.Routes.MapRoute
            (
                area + actionName,
                String.Format( "Administration/Corporate/{{controller}}/{{Id}}/{0}/{{{1}}}/{2}",
                                area,
                                idName,
                                actionName ),
                new { action }
            );
    }
