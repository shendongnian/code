    [HttpPost]
    public ActionResult Create([Bind(Prefix = "request")] WorkRequest newRequest)
    {
        //model.request should be properly bound here
        try
        {
            storeDB.AddToWorkRequests(newRequest);
            storeDB.SaveChanges();
            return RedirectToAction("Index");
        }
        catch
        {
            return View();
        }
    }
