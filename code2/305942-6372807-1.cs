     foreach (var newitem in newItemsList)
     {
      if (newitem.SomeValue > 0)
      {  
          MyEntityType obj = new MyEntityType();
          obj = newitem;
          myContext.AddToMyEntityType(obj);
      }
     }
      dbcontext.SaveChanges();
