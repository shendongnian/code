    public ActionResult Create()
    {
        var model = new EditGrantApplicationViewModel 
        {
            Titles = grantApplicationService.GetTitles()
        };
        return View(model);
    }
    [HttpPost]
    public ActionResult Create(EditGrantApplicationViewModel model)
    {
        if (!ModelState.IsValid)
        {
            // Reload the Titles as we are redisplaying the same view
            // and they were not part of the view model that was submitted
            model.Titles = grantApplicationService.GetTitles();
            return View("Create", model);
        }
        return View("Index");
    }
