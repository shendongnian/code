    List<int> GetParentHierarchy(int startingId)
    {
      List<int> hierarchy = new List<int> { startingId };
      using(Connection db = new Connection()) //change to your context
      {      
          int parentId = startingId;
          while(true)
          {
             var foo = db.Foo(x => x.Id == parentId).SingleOrDefault(); 
             if(foo == null)
               break;
             parentId = foo.ParentId;
             hierarchy.Add(foo.Id);
             if(foo.BaseParentID == 0)
               break;
          }
      }
    
      return hierarchy;
    
    }
