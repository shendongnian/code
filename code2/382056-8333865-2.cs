    public ActionResult Index(int? id)
    {
        Models.MyProjectEntities entity = new Models.MyProjectEntities();
         // NORMAL QUERY, NO PROBLEM
         //var Messages = entity.Message.Where(x => x.Active);
         // JOINED QUERY, GENERATES ERROR
         var Messages = entity.Message.Join(entity.Categories, 
                            m => m.CategoriID,
                            k => k.CategoriID,
                            (m, k) => new MessageWithCategories { Message = m, Categories = k })
                            .Where(x => x.Message.Active);
        return View(Messages);
    }
