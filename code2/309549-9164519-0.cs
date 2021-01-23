    public static IEnumerable<TEntity> LoadedEntities<TEntity>(this ObjectContext Context)
    {
        return Context.ObjectStateManager
            .GetObjectStateEntries(EntityState.Added | EntityState.Modified | EntityState.Unchanged)
            .Where(e => !e.IsRelationship).Select(e => e.Entity).OfType<TEntity>();
    }
