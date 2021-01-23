    public ActionResult Register()
    {
        var model = new RegisterViewModel();
        return View(model);
    }
    [HttpPost]
    public ActionResult Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        // TODO: perform the registration
        return RedirectToAction("success");
    }
