    public ActionResult Index() 
    {  
        var obj = new SomeModel();
        return View(obj); 
    } 
    [HttpPost]
    public ActionResult Index(SomeModel obj) 
    {  
        // update logic
        return View(obj); 
    } 
