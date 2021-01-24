    using (var context = new AppContext())
    {
         var myEntity = context.Entities.Single(x => x.EntityId = entityId);
         SomeService.DoSomething(myEntity);
    }
