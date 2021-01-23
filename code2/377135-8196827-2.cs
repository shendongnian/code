    private IQueryable<T> FilterDeletedEntities<T>(IQueryable<T> entities)
    {
        if (typeof(IDeletable).IsAssignableFrom(typeof(T)))
        {
            return this.FilterDeletedFromDeletable( entities );
        }
        return entities;
    }
    private IQueryable<T> FilterDeletedFromDeletable<T>( IQueryable<T> entities ) where T : IDeletable
    {
        return entities.Where( e => !e.Deleted );
    }
