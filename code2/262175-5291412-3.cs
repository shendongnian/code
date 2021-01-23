    var routeValues = new RouteValueDictionary(new 
    {
        action = "Error",
        controller = "Home",
        Message = "You do not have sufficient access to complete your request.",
        Status = HttpStatusCode.Unauthorized,
        // Remark: never use HttpContext.Current :
        UserHost = filterContext.HttpContext.Request.UserHostAddress,
        Date = DateTime.Now.ToString("u")
    });
    filterContext.Result = new RedirectToRouteResult(routeValues);
