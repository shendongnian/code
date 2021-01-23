    [HttpPost]
    public ActionResult CreateNew(TrollModel trollModel)
    {
        TempData["troll"] = trollModel;
        return RedirectToAction("Index");
    }
    public ActionResult Index()
    {
        var trollModel = TempData["troll"] as TrollModel;
        if (trollModel == null)
        {
            trollModel = new TrollModel
            {
                Name = "Default Troll", 
                Age = "666"
            };
        }
        return View(trollModel);
    }
