    public ActionResult Index()
            {
    
                var lastblogg = db.Bloggs.OrderByDescending(o => o.ID).Take(1).FirstOrDefault();
                var list = new List<DishBlogg>();
                list.Add(new DishBlogg(){Blog = lastblog});
    
                return View(list);
            }
