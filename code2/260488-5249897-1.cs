    public ActionResult Index()
    {
        var professions = new[] { "Prof1", "Prof2", "Prof3", "Prof4", "Prof5" }
             .Select(x => new SelectListItem { Value = x, Text = x });
        var model = new MyViewModel
        {
            ProfessionList = new SelectList(professions, "Value", "Text")
        }
        return View(model);
    }
