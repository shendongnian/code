            public ActionResult Index()
            {
    
                Session["Test"] = "Session Clean Test";
                return View();
            }
