    using (SomeDataContext db = new SomeDataContext())
    {
         List<DbItem> dbItems = new List<DbItem>();
    
         foreach(Item i in Items)
         {
              DbItem d = new DbItem;
              d.value = i.value;
              //.... etc ...
    
              dbItems.Add(d);
         }
    
         db.InsertAllOnSubmit(dbItems);
         db.SubmitChanges();
    }
