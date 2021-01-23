    [HttpPost]
    public ActionResult Index(Dummy dum)
    {
        var dsad = dum;
        var a = dum.Name;        //get Name of Dummy
        var b = dum.Dum.Name;    //get Name of InnerDummy of Dummy
    
        return RedirectToAction("index");
    }
