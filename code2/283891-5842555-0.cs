    public void SaveOrUpdate(MyEntity entity)
    {
        if (entity.Id == 0)
        {
            context.MyEntities.AddObject(entity);
        }
        else
        {
            context.MyEntities.Attach(entity);
            context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
        }
        // You can call SaveChanges here or you can call it separately after multiple changes
    }
