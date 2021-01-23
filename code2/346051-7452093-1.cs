    ViewEngines.Engines.Clear();
    ViewEngines.Engines.Add(new RazorViewEngine().ControllerViews());
    ViewEngines.Engines.Add(new WebFormViewEngine().ControllerViews());
    ViewEngines.Engines.Add(new RazorViewEngine().SharedViews());
    ViewEngines.Engines.Add(new WebFormViewEngine().SharedViews());	
