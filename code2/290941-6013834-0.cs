    public ActionResult Index()
    {
        var model = new MyViewModel
        {
            MyProperty = "initial value"
        };
        return View(model);
    }
