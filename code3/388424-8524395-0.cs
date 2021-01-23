    private static RequestContext RequestContext(this HttpContext context)
    {
        var httpContextBase = new HttpContextWrapper(context);
        var routeData = new RouteData();
        return new RequestContext(httpContextBase, routeData);
    }
    private static RouteData GetRoute(this ActionResult url)
    {
        var data = url.GetRouteValueDictionary();
        var route = new RouteData();
        foreach (var item in data)
            route.Values[item.Key] = item.Value;
        return route;
    }
    public static string ExecuteAsString(this T4MVC_ActionResult result)
    {
        var controllerName = result.Controller;
        var context = HttpContext.Current.RequestContext();
        context.RouteData = result.GetRoute();
        var controller = (ControllerBase)ControllerBuilder.Current.GetControllerFactory().CreateController(context, controllerName);
        controller.ControllerContext = new ControllerContext(context, controller);
        var htmlHelper = new HtmlHelper(new ViewContext(
                                  controller.ControllerContext,
                                  new WebFormView(controller.ControllerContext, "HACK"),
                                  new ViewDataDictionary(),
                                  new TempDataDictionary(),
                                  new StringWriter()),
                            new ViewPage());
        return htmlHelper.Action(result).ToString();
    }
