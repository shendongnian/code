    foreach (var newitem in newItemsList)
    {
          if (newitem.SomeValue > 0)
          {
              dbcontext.AddObject("entity set name", newitem);
          }
    }
    dbcontext.SaveChanges();
