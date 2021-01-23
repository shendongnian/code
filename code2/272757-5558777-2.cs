    var id = myEntity.Id;
    if (context.MyEntities.Any(e => e.Id == id))
    {
        context.MyEntities.Attach(myEntity);
        context.ObjectStateManager.ChangeObjectState(myEntity, EntityState.Modified);
    }
    else
    {
        context.MyEntities.AddObject(myEntity);
    }
    context.SaveChanges();
