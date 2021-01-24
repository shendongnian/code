    using (var context = new MyContext())
    { 
       var factory = context.Factories.Single(x => x.FactoryId == factoryId); 
       var member = new Member
       {
          Factory = factory;
          // ... 
       }
       context.Members.Add(member);
       context.SaveChanges();
       return member;
    }
