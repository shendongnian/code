    public override int SaveChanges(SaveOptions options)
    {
        var entities = ObjectStateManger.GetObjectStateEntries(EntityState.Added | EntityState.Modified)
                                        .Select(e => e.Entity)
                                        .OfType<YourEntityType>();
    
        DateTime now = DateTime.Now;
        foreach(var entity in entities)
        {
            entity.Updated = now;
        }
    
        return base.SaveChanges(options);
    }
