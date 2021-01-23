    using(var myContext = new MyContext(connectionString))
    {
      var query = from o in myContext.MyEntities
                  where o.Flag == false
                  select o.Id;
      foreach (var id in query)
      {
        var entity = new MyEntity
          {
            Id = id,
            Flag = true
          };
        myContext.Attach(entity);
        myContext.ObjectStateManager.GetObjectStateEntry(entity).SetModifiedProperty("Flag");
      }
    
      myContext.SaveChanges();
    }
