     foreach (var newitem in newItemsList)
     {
      if (newitem.SomeValue > 0)
      {  
          MyEntityType obj = new MyEntityType
          {
           value1 = newitem.somevalue,
           value2 = newitem.someothervalue
          };
         
          myContext.AddToMyEntityType(obj);
      }
     }
      dbcontext.SaveChanges();
