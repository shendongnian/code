    public ActionResult Index()
    {
        using (MyEntities db = new MyEntities())
        {
            var model = 
                from c in db.Categories
                select new CategoryViewModel
                { 
                    Id = c.CategoryID, 
                    Name = c.Name 
                };
            return View(model.ToList());
        }
    }
