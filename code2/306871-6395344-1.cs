    var entities = context.ChangeTracker
                          .Entries<YourEntityType>()
                          .Where(e.State == EntityState.Added || e.State == EntityState.Modified)
                          .Select(e => e.Entity);
    foreach(var entity in entities)
    {
        entity.Validate();
    }
