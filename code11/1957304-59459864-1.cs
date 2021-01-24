    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.MapRoute(
            name: "FoodRecipeDetail",
            url: "{title}").RouteHandler = new FoodRecipeRouteHandler();
    }
