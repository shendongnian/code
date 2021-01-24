	public static void RegisterRoutes(RouteCollection routes)
	{
		routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
		routes.Add(new Route("K/{id}", new RedirectRouteHandler("K")));
		routes.MapRoute(
			name: "K",
			url: "Home/K/{id}",
			defaults: new { controller = "Home", action = "K", name = UrlParameter.Optional }
			);
		routes.MapRoute(
			name: "Default",
			url: "{controller}/{action}/{id}",
			defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
		);
	}
