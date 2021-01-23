    public static void RegisterRoutes(RouteCollection routes)
    {
		routes.MapRoute(
			"Default",
			"{controller}/{action}/{id}",
			new { id = RouteParameter.Optional });
    }
    //Test URL: http://localhost/MyProject/Test/GetMyId/123
