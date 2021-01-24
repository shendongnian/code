    public override int SaveChanges()
    {
        var entries = ChangeTracker.Entries<JoinEntity>().ToList();
        // Filter the entries that are being deleted
        foreach (var entry in entries.Where(entry.State == EntityState.Deleted))
        {
            // Change the entry so it instead updates the entry and does not delete it
            entry.Entity.Ended = DateTime.Now;
            entry.State = EntityState.Modified;
        }
        return base.SaveChanges();
    }
