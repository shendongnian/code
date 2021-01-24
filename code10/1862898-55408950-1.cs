    EntityB entityB = new EntityB();
    dbContext.EntityBs.Add(entityB);
    
    EntityA entityA = new EntityA();
    entityA.EntityBId = entityB.EntityBId;
    dbContext.EntityAs.Add(entityA);
    dbContext.SaveChanges();
