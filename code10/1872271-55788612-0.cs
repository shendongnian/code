    public override int SaveChanges()
    {
        ChangeTracker.DetectChanges();
        var entries = ChangeTracker.Entries().Where(e => !(e.Entity is Audit) && e.State != EntityState.Detached && e.State != EntityState.Unchanged);
        foreach (var entry in entries)
        {
            switch (entry.State)
            {                    
                case EntityState.Modified:
                    foreach (var property in entry.Properties)
                    {
                        if (property.IsModified)
                        {
                            var original = entry.GetDatabaseValues().GetValue<object>(property.Metadata.Name);
                            var current = property.CurrentValue;
                        }
                    }
                    break;
            }
        }
        return base.SaveChanges();
    }
