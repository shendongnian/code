     public ActionResult Create(int id, FormCollection collection)
     {
          MyModel model = Repository.Get(id); // in your case EF productosBD.Where(x=>x.Id = id)
          UpdateMode(model, collection);
          Repository.Save(model);
         
