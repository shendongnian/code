    public override int SaveChanges()
    {
        // Get all entries of the change trackes (of a given type)
        var entries = ChangeTracker.Entries<IAuditedEntity>().ToList();
        // Filter the entries that are being deleted
        foreach (var entry in entries.Where(entry.State == EntityState.Deleted))
        {
            // Change the entry so it instead updates the entry and does not delete it
            entry.Entity.DeletedOn = DateTime.Now;
            entry.State = EntityState.Modified;
        }
        return base.SaveChanges();
    }
