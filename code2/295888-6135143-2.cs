    protected string ViewContent(string view)
    {
      return ViewContent(view, (string)null);
    }
    protected string ViewContent(string view, string controller)
    {
      return ViewContent(view, controller, (object)null);
    }
    protected string ViewContent(string view, object model)
    {
      return ViewContent(view, (string)null, model);
    }
    protected string ViewContent(string view, 
      string controller, object model)
    {
      view.ThrowIfWhitespaceOrNull("view");
      if (string.IsWhitespaceOrNull(controller)
        controller = ControllerContext.
                     RouteData.GetRequiredString("controller");
      ViewDataDictionary viewData = 
        new ViewDataDictionary(ViewData) { Model = model };
			
      return ViewContent(view, controller, viewData);
    }
