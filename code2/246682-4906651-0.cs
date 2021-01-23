    public class EntityA : IEntity
    {}
    
    public class EntityB : IEntity
    {}
    
    List<IEntity> results = 
    (from a in EntityAList select a).Cast<IEntity>()
    .Concat(
    (from b in EntityBList select b).Cast<IEntity>()
    )
    .Fetch(N).ToList();
    
    foreach (IEntity entity in results)
    {
     if (entity is EntityA)
      // do something with entity A
     if (entity is EntityB)
      // do something with entity B
    }
