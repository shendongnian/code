    [OutputCache(CacheProfile = "VideoIndexView")]
    public ActionResult Index()
    {
        ...
        return View(model);  // Really only return a model that is okay to be cached
    }
    public ActionResult LoadData ()
    {
        var Result = // Load the data
        ...
        return Json(Result);  // Don't forget to allow GET here if you're using HTTPGET
    }
    // Or...
    public ActionResult LoadData ()
    {
        var Result = // Load the data
        ...
        return PartialView (Result);
    }
