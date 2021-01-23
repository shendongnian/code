    private void ThrowIfInvalidConcurrencyToken()
    {
        foreach (var entry in _context.ChangeTracker.Entries())
        {
            if (entry.State == EntityState.Unchanged) continue;
            foreach (var entryProperty in entry.Properties)
            {
                if (!entryProperty.IsModified || !entryProperty.Metadata.IsConcurrencyToken) continue;
                if (entryProperty.OriginalValue != entryProperty.CurrentValue)
                {                    
                    throw new DbUpdateConcurrencyException(
                        $"Entity {entry.Metadata.Name} has been modified by another process",
                        new List<IUpdateEntry>()
                        {
                            entry.GetInfrastructure()
                        });
                }
            }
        }
    }
