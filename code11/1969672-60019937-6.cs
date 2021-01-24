    public ActionResult Index()
    {
        var magazyn = db.Magazyn.Include(m => m.Tools).Include(m => m.Person);
        ViewBag.PersonCount = db.Person.Count();    
    
        return View(magazyn.ToList());
    }
