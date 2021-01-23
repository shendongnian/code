    public ActionResult Index()
    {
        var lastblogg = db.Bloggs.OrderByDescending(o => o.ID).Take(1).ToList();
        return View(lastblogg);
    }
