    public ActionResult Index()
    {
        var model = PrepareModel(_messages);
        return View(model);
    }
