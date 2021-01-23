    if (myEntity.Id != 0)
    {
        context.MyEntities.Attach(myEntity);
        context.ObjectStateManager.ChangeObjectState(myEntity, EntityState.Modified);
    }
    else
    {
        context.MyEntities.AddObject(myEntity);
    }
    
    context.SaveChanges();
