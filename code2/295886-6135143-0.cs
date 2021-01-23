    public string ViewContent(string view, 
      string controller, ViewDataDictionary viewData)
    {
      var routeData = new System.Web.Routing.RouteData(
        RouteData.Route, RouteData.RouteHandler);
      routeData.DataTokens.Clear();
      foreach (var item in RouteData.DataTokens)
      {
        routeData.DataTokens.Add(item.Key, item.Value);
      }
      foreach (var item in RouteData.Values)
      {
        routeData.Values.Add(item.Key, item.Value);
      }
      //then overwrite the controller - not the action, though
      routeData.Values["controller"] = controller;
      var controllerContext = new ControllerContext(
        HttpContext, 
        routeData, 
        this);
      ViewEngineResult result = ViewEngines.Engines.FindView(
        controllerContext, 
        view, 
        null);
      string content = null;
      if (result.View != null)
      {
        using (StringWriter output = new StringWriter())
        {
          ViewContext viewContext = new ViewContext(
            controllerContext, result.View, viewData, TempData, output);
          
          viewContext.View.Render(viewContext, output);
          result.ViewEngine.ReleaseView(ControllerContext, viewContext.View);
          content = output.ToString();
        }
        return content;
      }
      else
        throw new InvalidOperationException("Can't find view");
    }
