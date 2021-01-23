    public string RenderViewAsString(ControllerContext context, string viewName, object model)
    {
    	if (string.IsNullOrEmpty(viewName))
    		viewName = context.RouteData.GetRequiredString("action");
    
    	var view = ViewEngines.Engines.FindView(context, viewName, null).View;
    	if (view != null)
    	{
    		var sb = new StringBuilder();
    		using (var writer = new StringWriter(sb))
    		{
    			var viewContext = new ViewContext(context, view,
    					new ViewDataDictionary(model), new TempDataDictionary(), writer);
    			view.Render(viewContext, writer);
    			writer.Flush();
    		}
    		return sb.ToString();
    	}
    	return string.Empty;
    }
