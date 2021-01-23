    public ActionResult Blah()
    {
      MyViewModel model = new MyViewModel();
      using (var dbc = new MyDbContext())
      {
        model.items = from x in dbc.items select x;
      }    
      View(model)
    }
