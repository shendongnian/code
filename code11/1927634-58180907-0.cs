    public string RenderRazorViewToString(string viewName, object model)
    	{
    		ViewData.Model = model;
    		using (var sw = new StringWriter())
    		{
    			var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
    			var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
    			viewResult.View.Render(viewContext, sw);
    			viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
    			return sw.GetStringBuilder().ToString();
    		}
    	}
