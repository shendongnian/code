    [HttpPost]
    public ActionResult Index(FormCollection collection)
    {
        var m = new Model();
        m.Value = collection["Value"] + "1";
        return View(m);
    }
