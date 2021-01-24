    public ActionResult Index()
    {
        var model = new MyModel();
        //load the data from a source
        model.dt = LoadFromDB();
        return View(model);
    }
    [HttpPost]
    public ActionResult Index(MyModel model)
    {
        //do stuff here on form post
        //load the data again since it is not retained in a ViewSate
        //if you do not then dt will be null
        model.dt = LoadFromDB();
        return View(model);
    }
