    EntityB entityB = dbContext.EntityBs.FirstOrDefault(yourCondition) 
    
    EntityA entityA = new EntityA();
    entityA.EntityBId = entityB.EntityBId;
    
    dbContext.EntityAs.Add(entityA);
    dbContext.SaveChanges();
