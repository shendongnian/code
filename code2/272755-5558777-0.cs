    if (context.ObjectStateManager.GetObjectStateEntry(myEntity).State == EntityState.Detached)
    {
        context.MyEntities.AddObject(myEntity);
    }
    
    // Attached object tracks modifications automatically
    
    context.SaveChanges();
