    private IQueryable<T> FilterDeletedEntities<T>(IQueryable<T> entities)
    {
        if (typeof(IDeletable).IsAssignableFrom(typeof(T)))
        {
            var deletableEntities = (IQueryable<IDeletable>)entities;
            return deletableEntities.Where(entity => !entity.Deleted).Cast<T>();
        }
        return entities;
    }
