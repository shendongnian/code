    var ms = new MemoryStream();
	using (var sw = new StreamWriter(ms))
	{
	   using (var tw = new HtmlTextWriter(sw))
	   {
		ViewEngineResult viewResult = ViewEngines.Engines.FindView(controller.ControllerContext, viewName, null);
		ViewContext viewContext = new ViewContext(controller.ControllerContext, viewResult.View, controller.ViewData, controller.TempData, sw);
		viewResult.View.Render(viewContext, tw);
		ms.Position = 0;
	    }
      return ms;
	}
