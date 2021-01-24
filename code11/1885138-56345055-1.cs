    public ActionResult Index()
    {
        var today = DateTime.Now;
        var model = new SampleViewModel(today, today.AddDays(5));
    
        return View(model);
    }
