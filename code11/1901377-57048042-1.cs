    using (var context = new MyContext())
    { 
       // Call some code using this context that results in the following running...
       var factory = context.Factories.Single(x => x.FactoryId == 3);
       // more code...
       
       var member = new Member
       {
          FactoryId = 3;
          // ... 
       }
       context.Members.Add(member);
       context.SaveChanges();
       return member;
    }
