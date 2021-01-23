    public ActionResult Index()
    {
        var model = new MyViewModel
        {
            TimeZones = new SelectList(EventModel.getTIMEZOMES, "Key", "Value")
        };
        return View(model);
    }
