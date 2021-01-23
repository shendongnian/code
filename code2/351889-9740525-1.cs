    public ActionResult Index()
    {
        var lastblogg = db.Bloggs.OrderByDescending(o => o.ID).Take(1);
        var lastdish = db.Bloggs.OrderByDescending(o => o.ID).Take(1);
        var viewModel = new DishBlogg(lastblogg , lastdish );
    
        return View("Index", viewModel);
    }
