    public ActionResult Index()
    {
        return View(GetModel());
    }
    
    public ActionResult Result Child(string id)
    {
        return View(GetModel(id));
    }
    
    public ActionResult Result SubChild(int id)
    {
        return View(GetModel(id));
    }
