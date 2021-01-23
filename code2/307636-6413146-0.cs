    public ActionResult Test()
    {
        using (MyEntities db = new MyEntities())
        {
            var model = from c in db.Categories;
    
            return View(model.ToList());
        }
    }
