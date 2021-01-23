    actionContext.Result = new RedirectToRouteResult(
        new RouteValueDictionary(new { controller = "Home", action = "Error" })
    );
    
    actionContext.Result.ExecuteResult(actionContext.Controller.ControllerContext);
