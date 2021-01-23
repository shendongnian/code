    public ActionResult Index()
    {
        var reminders = new[]
        {
            new Reminders 
            {
                Reminder = new List<SelectListItem> 
                { 
                    new SelectListItem { Value = "1", Text = "reminder 1" },
                    new SelectListItem { Value = "2", Text = "reminder 2" },
                },
            },
            new Reminders
            {
                Reminder = new List<SelectListItem> 
                { 
                    new SelectListItem { Value = "1", Text = "reminder 1" },
                    new SelectListItem { Value = "2", Text = "reminder 2" },
                    new SelectListItem { Value = "3", Text = "reminder 3" },
                },
            }
        };
        return View(reminders);
    }
