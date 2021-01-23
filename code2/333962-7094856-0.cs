    public override void OnActionExecuted(ActionExecutedContext filterContext)
    {
        var stream = filterContext.HttpContext.Response.Filter;
        string response = new StreamReader(stream).ReadToEnd();
        ContentResult contres = new ContentResult();
        contres.Content = response;
        filterContext.Result = contres;
    }
