    public ActionResult FirstCall()
    {
        TempData["Param1"] = "Param1";
        return View();
    }
    public ActionResult SecondCall()
    { 
        ViewModel model = new ViewModel();
        model.param1 = TempData["Param1"];
        return View();
    }
