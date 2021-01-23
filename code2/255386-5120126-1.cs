    public ActionResult Index()
    {
        var model = new PersonViewModel
        {
            Roles = new[]
            {
                new SelectListItem { Text = "User", Value = "0" },
                new SelectListItem { Text = "Admin", Value = "1" }
            }
        };
        return View(model);
    }
