    [HttpPost]
    public ActionResult Index(Register registration)
    {
        try
        {
            User newUser = RegistrationManager.Register(registration);
            return RedirectToAction("Index", "District", newUser.ID);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("There has been an Error during Registration", ex.Message);
            return RedirectToAction("Details", "Error", ex);
        }
        return View(registration);
    }
