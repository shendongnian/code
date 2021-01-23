    public void OnError(HttpContextBase context)
    {
        context.ClearError();
        context.Response.StatusCode = 404;
        var rd = new RouteData();
        rd.Values["controller"] = "error";
        rd.Values["action"] = "notfound";
        IController controller = new ErrorController();
        var rc = new RequestContext(context, rd);
        controller.Execute(rc);
    }
