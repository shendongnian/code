    [AcceptVerbs(HttpVerbs.Get), ImportModelStateFromTempData]
    public ActionResult Index(YourModel stuff)
    {
        return View();
    }
    
    [AcceptVerbs(HttpVerbs.Post), ExportModelStateToTempData]
    public ActionResult Submit(YourModel stuff)
    {
        if (ModelState.IsValid)
        {
            try
            {
                //save
            }
            catch (Exception e)
            {
                ModelState.AddModelError(ModelStateException, e);
            }
        }
    
        return RedirectToAction("Index");
    }
