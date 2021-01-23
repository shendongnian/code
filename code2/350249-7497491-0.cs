    public ActionResult Index()
    {
        var lastRecipe = db.Dishes.OrderByDescending(o => o.ID).Take(1);
        var lastblogg = db.Bloggs.OrderByDescending(o => o.ID).Take(1);
       var model = new BloggRecipeModel(lastRecipe, lastblogg);
       return View(model);
   }
