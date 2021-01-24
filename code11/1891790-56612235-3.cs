    public ActionResult Index(int Id)
    {
        LoginViewModel model = (LoginViewModel) TempData["LoginModel"];
        ViewBag.error = TempData["LoginError"];
        //Do other logic
        return View(model);
    }
