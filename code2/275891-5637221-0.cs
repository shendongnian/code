    public ActionResult(int column1, int column2) 
    {
         var query = from m in _db.MyTable
                      where m.Column1 == column1
                      where m.Column2 == column2
                      select m;
                      // Or this for typed model
                      // select new MyModel { Column1 = m.Column1, etc }
         var model = query.First();
                    
         return View(model);
    }
