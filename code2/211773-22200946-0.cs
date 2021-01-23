    @helper NavigationLink(string linkText, string actionName, string controllerName)
    {
        if(ViewContext.RouteData.GetRequiredString("action").Equals(actionName, StringComparison.OrdinalIgnoreCase) &&
           ViewContext.RouteData.GetRequiredString("controller").Equals(controllerName, StringComparison.OrdinalIgnoreCase))
        {
            <span>@linkText</span>
        }
        else
        {
            @Html.ActionLink(linkText, actionName, controllerName);
        }
    }
