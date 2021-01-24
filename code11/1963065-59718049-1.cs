    var entityEntries = ChangeTracker
                        .Entries()
                        .Where(e => e.Entity is BaseEntity
                                    && (e.State.Equals(EntityState.Added) || 
    e.State.Equals(EntityState.Modified))
                                    && !e.Metadata.IsOwned());
