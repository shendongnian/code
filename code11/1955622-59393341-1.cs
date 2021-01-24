    public override int SaveChanges()
    {
        this.ChangeTracker.DetectChanges();
        var added = this.ChangeTracker.Entries()
                    .Where(t => t.State == EntityState.Deleted)
                    .Select(t => t.Entity)
                    .ToArray();
    
        foreach (var entity in added)
        {
            if (entity is IFileSystemEntity)
            {
                var track = entity as IFileSystemEntity;
                // Remove logic here
            }
        }
        return base.SaveChanges();
    }
