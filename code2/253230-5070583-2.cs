    public ActionResult Index(int id)
    {
        SomeViewModel model = ...
        return View(model);
    }
    
    [HttpPost]
    public ActionResult Index(SomeViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        // TODO: do something with the model your got from the view
        return RedirectToAction("Success");
    }
