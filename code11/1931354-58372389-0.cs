        var changedEntriesCopy = _dbEntities.ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Added ||
                        e.State == EntityState.Modified ||
                        e.State == EntityState.Deleted)
            .ToList();
        await _dbEntities.SaveChangesAsync();
        foreach (var entry in changedEntriesCopy)
            entry.State = EntityState.Detached;
