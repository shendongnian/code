    string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
    string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();
    if (actionName.Equals("index", StringComparison.InvariantCultureIgnoreCase))
    {
    	actionName = string.Empty;
    }
    string result = $"/{controllerName}/{actionName}";
