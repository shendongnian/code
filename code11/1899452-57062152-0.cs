    public static void Map(ControllerModel model)
    {
        string templatePrefix = "api/services/app";
        ...
        foreach (var action in model.Actions)
        {
            var verb = ProxyScriptingHelper.GetConventionalVerbForMethodName(action.ActionName);
            var constraint = new HttpMethodActionConstraint(new List<string> { verb });
    
            foreach (var selector in action.Selectors)
            {
                selector.ActionConstraints.Add(constraint);
                selector.AttributeRouteModel = new AttributeRouteModel(new RouteAttribute($"{templatePrefix.EnsureEndsWith('/')}{action.Controller.ControllerName}/{action.ActionName}"));
            }
        if (AppStore.Contains(model.ControllerName))
                {
                    templatePrefix = "api/services/AppStore";
                    var sm = new SelectorModel
                    {
                        AttributeRouteModel = new AttributeRouteModel(new RouteAttribute(
                            $"{templatePrefix.EnsureEndsWith('/')}{action.Controller.ControllerName}/{action.ActionName}"))
                    };
                    sm.ActionConstraints.Add(constraint);
                    action.Selectors.Add(sm);
                }
        }
    }
