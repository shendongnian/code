    [HttpPost]
    public ActionResult UserRegistration(SiteUserModels.SiteUserRegistrationModel model)
    {
        if (ModelState.IsValid)
        {
            SiteUserRepository.CreateUser(model.username, model.email, model.password, model.firstname, model.firstname, model.timezone_id);
            return RedirectToAction("Index", "Home");
        }
        return UserRegistration();
    }
