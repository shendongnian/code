    [HttpPost]
    public ActionResult Create(ViewModelUsedToStronglyTypeTheView model)
    {
        //model.request should be properly bound here
        try
        {
            storeDB.AddToWorkRequests(model.request);
            storeDB.SaveChanges();
            return RedirectToAction("Index");
        }
        catch
        {
            return View(model);
        }
    }
