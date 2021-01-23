    IQueryable<Table> GetStuff()
    {
      using(var db = new DataContext())
      {
         return db.Tables.Where(i=>i.Id == 1);
      }
    }
