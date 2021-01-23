    public ActionResult Index() {
    
      var _entities = new MyDataEntity();
      var model = _entities.Person;
      model = model.Where(x => x.Age > 20);
    
      return View(model);
      
    }
