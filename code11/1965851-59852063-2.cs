    [HttpGet]
    public IActionResult Index()
    {
        var model = new AppointmentViewModel()
        {
            Purposes = new List<SelectListItem>
            {
                new SelectListItem{Text = "Value1", Value = "1"},
                new SelectListItem{Text = "Value2", Value = "2"},
                new SelectListItem{Text = "Value3", Value = "3"},
                new SelectListItem{Text = "Value4", Value = "4"}
            }
        };
        return View(model);
    }
    [HttpPost]
    public IActionResult Index(AppointmentViewModel model, int Id)
    {
        //do your stuff...
        return View(model);
    }
