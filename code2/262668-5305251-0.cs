    using (var context = new MyContext())
    {
       var firstEntity = new FirstEntity { Id = firstId };
       var secondEntity = new SecondEntity { Id = secondId; }
       context.FirstEntities.Attach(firstEntity);
       context.SecondEntities.Attach(secondEntity);
       firstEntity.SecondEntities = new HashSet<SecondEntity>();
       firstEntity.SecondEntities.Add(secondEntity);
       context.SaveChanges();
    }
