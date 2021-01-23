    public ActionResult Register(RegisterViewModel model)
    {
        return View(model);
    }
    [HttpPost]
    [ActionName("Register")]
    public ActionResult ProcessRegistration(RegisterViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        // TODO: perform the registration
        return RedirectToAction("success");
    }
