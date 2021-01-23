    public ActionResult Index()
    {
        var model = new MyViewModel
        {
            Message = TempData["message"] as string;
        };
        return View(model);
    }
