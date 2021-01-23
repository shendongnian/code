    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        routes.MapRoute(
            "Default",
            "{controller}/{action}/{id}",
            new { controller = "Home", action = "Index", id = UrlParameter.Optional },
            new { controller = "^((?!JsAction).)*$", action = "^((?!JsAction).)*$" }
        );
        routes.Add("JsActionRoute", JsAction.JsActionRouteHandlerInstance.JsActionRoute);
    }
