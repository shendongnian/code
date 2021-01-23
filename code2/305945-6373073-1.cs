    var entitySet = dbcontext.CreateObjectSet<item type>();
    foreach (var newitem in newItemsList)
    {
          if (newitem.SomeValue > 0)
          {
              entitySet.AddObject(newitem);
          }
    }
    dbcontext.SaveChanges();
