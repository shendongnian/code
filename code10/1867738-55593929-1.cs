    public ActionResult Index()
    {
        return View();
    }
    
    [HttpPost]
    public ActionResult Index(Test  mdltest)
    {
       //Your data processing over here
       ViewBag.Sucess = "yes"; //For prevent partial view calling when form not submit
       return View("_PartialPage", mdltest);
    }
