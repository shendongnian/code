    [HttpPost]
    public ActionResult Index(Dummy postback)
    {
        var dsad = postback;
        var a = postback.Name;        //get Name of Dummy
        var b = postback.Dum.Name;    //get Name of InnerDummy of Dummy
    
        return RedirectToAction("index");
    }
