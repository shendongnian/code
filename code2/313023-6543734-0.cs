    public ActionResult Index(string id)
    {
        TrollModel trollModel;
        if (string.IsNullOrEmpty(id))
        {
            trollModel = new TrollModel()
                                    {
                                        Name = "Default Troll", 
                                        Age = "666"
                                    };
        }
        else
        {
            trollModel = GetFromPersisted(id);
        }
        return View(trollModel);
    }
