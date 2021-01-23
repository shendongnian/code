    if (model.UserName == User.Identity.Name && model.IsAdmin == false)
    {
        ModelState.AddModelError("", "You cannot remove your own admin privileges");
        ModelState.Remove("IsAdmin");
        model.IsAdmin = true;
        return View(model);
    }
