    [HttpPost]
    public ActionResult Create(UserViewModel model)
    {
        if (ModelState.IsValid)
        {
            int id = UserService.CreateFromViewModel(model);
            return RedirectToAction("View", new { id });
        }
        return View(model);
    }
