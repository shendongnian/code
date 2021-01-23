    public IHtmlString ActionLink<T>(this HtmlHelper htmlHelper, Expression<Action<T>> action, string linkText) where T : Controller
    {
      var methodCall = action.Body as MethodCallExpression;
      if (methodCall == null)
        throw new ArgumentException("Action must be a method call", "action");
    
      var actionName = methodCall.Method.Name;
      var controllerName = GetControllerName(typeof(T));
    
      return htmlHelper.ActionLink(linkText, actionName, controllerName);
    }
    
    public static string GetControllerName(Type controllerType)
    {
      return controllerType.Name.Substring(0, controllerType.Name.Length - "Controller".Length);
    }
