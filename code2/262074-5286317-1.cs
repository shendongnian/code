    public ActionResult Index()
    {
        var model = new MyViewModel
        {
            LicenseName = HttpContext.Application["LICENSE_NAME"] as string
        };
        return View(model);
    }
