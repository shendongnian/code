    public IActionResult Create()
    {
          ViewBag.MumSport = new List<SelectListItem>
                {
                    new SelectListItem { Text = "nikako", Value = "1" },
                    new SelectListItem { Text = "rekreativno", Value = "2" },
                    new SelectListItem { Text = "amaterski", Value = "3" },
                    new SelectListItem { Text = "profesionalno", Value = "4" }
                }
   
          return View();
    }
    [HttpPost]
    public IActionResult Create(view model goes in here)
    {
          Business logic goes here
    }
