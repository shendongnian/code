    var entities = context.ObjectStateManager
                          .GetObjectStateEntries(EntitiState.Modified | EntityState.Added)
                          .Where(e => !e.IsRelationship)
                          .Select(e => e.Entity)
                          .OfType<YourEntityType>();
    foreach(var entity in entities)
    {
        entity.Validate();
    }
