    public ActionResult Edit(Table_2 emp)
    {
          var table2 = _dbContext.Table_2.Where(x => x.Id == emp.id).FirstOrDefault(); //SingleOrDefault() also used.
          if (table2 == null)
          {
               throw new Exception("not found");
          }
           table2.name = emp.name;
           table2.dprmt = emp.dep;
           dbs.SaveChanges();
           return RedirectToAction("Index");
    }
