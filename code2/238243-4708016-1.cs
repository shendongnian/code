    public ActionResult Action1()
    {
        TempData["message"] = "some message";
        return RedirectToAction("action2");
    }
    public ActionResult Action2()
    {
        var message = TempData["message"] as string;
        return View();
    }
