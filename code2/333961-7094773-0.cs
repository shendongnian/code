    public override void OnActionExecuted(ActionExecutedContext filterContext)
    {
        stream.Position = 0;
        string response = new StreamReader(stream).ReadToEnd();
        ContentResult contres = new ContentResult();
        contres.Content = response;
        filterContext.Result = contres;
    }
