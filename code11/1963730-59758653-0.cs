    var addedEntries = ChangeTracker.Entries()
        .Where(t => t.State == EntityState.Added)
        .ToList();
    addedEntries.ForEach(entry =>
    {
        if (entry.Entity is IAuditable auditable)
        {
            auditable.CreatedAt = utcNow;
            auditable.UpdatedAt = utcNow;
        }
        var foreignKeys = entry.Metadata.GetForeignKeys();
        var referencingForeignKeys = entry.Metadata.GetReferencingForeignKeys();
    });
 
