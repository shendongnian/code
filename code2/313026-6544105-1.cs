    [HttpPost]
    public ActionResult CreateNew(TrollModel trollModel)
    {
        return RedirectToAction("Index", new  
        {  
            Age = trollModel.Age, 
            Name = trollModel.Name 
        });
    }
    public ActionResult Index(TrollModel trollModel)
    {
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
