    public ActionResult Index()
    {
        var form = pa.Index(); // <-- This is the controller from controller A
        using (var sw = new StringWriter())
        {
            // Find the actual partial view.
            var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, form.ViewName);
            // Build a view context.
            var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
            // Render the view.
            viewResult.View.Render(viewContext, sw);
            // Get the string rendered.
            ViewBag.CMSForm = sw.GetStringBuilder().ToString();
        }
        return View();
    }
