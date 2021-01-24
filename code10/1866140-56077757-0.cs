    In WebApplicationModule2 we have an action like this and it will return the view.
    public IActionResult Index()
        {
            model objmodel = new model();
            return View("~/Home/Index.cshtml",objmodel );
        }
