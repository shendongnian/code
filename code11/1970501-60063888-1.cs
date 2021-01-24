    private void SetProps<TEntity>(TEntity dbEntity, EntityState newState) where TEntity : class, new()
    {
        var entry = Entry(dbEntity);
 
        if (dbEntity is IDbEntityBase)
        {
            if (newState == EntityState.Added)
            {
                entry.Property(nameof(IDbEntityBase.Id)).CurrentValue = Guid.NewGuid();
            }
        }
    }
