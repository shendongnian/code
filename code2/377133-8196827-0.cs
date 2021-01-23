    private IQueryable<T> FilterDeletedEntities<T>(IQueryable<T> entities)
    {
        if (typeof(IDeletable).IsAssignableFrom(typeof(T)))
        {
            return entities.Cast<IDeletable>()
                           .Where( e => !e.Deleted )
                           .Cast<T>();
        }
        return entities;
    }
