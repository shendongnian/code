    [HttpGet]
    public ActionResult Edit()
    {
        var model = new FilterViewModel 
        { 
            PossibleValues = new[]
            {
                new SelectListItem { Value = "1", Text = "value 1" },
                new SelectListItem { Value = "2", Text = "value 2" },
                new SelectListItem { Value = "3", Text = "value 3" },
            }
        };
        return View(model);
    }
