    foreach (ObjectStateEntry entry in
                    context.ObjectStateManager.GetObjectStateEntries(
                    EntityState.Added | EntityState.Modified))
    {
        dynamic dynamicEntity = entry.Entity;
    
        CallGenerateLog(dynamicEntity);
    }
