    public ActionResult Edit(int id, MenuModel menu)
    {
       var menuDb = repository.Get(id);
       TryUpdateModel(menuDb);
    
       //repository.save(menu); <-- WRONG!
       repository.save(menuDb); <-- BINGO... It works! 
    }
