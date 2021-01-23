    public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
    {
        return controllerContext.HttpContext.Request[ValueName] != null &&
               controllerContext.HttpContext.Request.HttpMethod == "GET";
    }
