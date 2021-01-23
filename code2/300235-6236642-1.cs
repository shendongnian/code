    public ActionResults Index()
    {
        var model = new MyService().GetModel();
        return View(model);
    }
