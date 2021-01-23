    public ActionResult Index()
    {
        SomeViewModel model = ...
        model.City = "default value";
        return View(model);
    }
