    public ActionResult Index()
    {
        var model = new DishBlogg
        {
            Blogging = db.Bloggs.OrderByDescending(o => o.ID).Take(1).ToList(),
            Dishing = db.Dishes.OrderByDescending(o => o.ID).Take(1).ToList(),
        }
        return View(model);
    }
