    If you did not want to invoke some action methods then you have to mark it with a attribute [NonAction] or by making it private
     public ActionResult Index()
            {
                return View();
            }
            [NonAction]
            public ActionResult Countries(List<string>countries)
            {
                return View(countries);
            }
