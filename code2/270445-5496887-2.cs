    public IQueryable<T> GetQuery<T>() where T : IEntity
    {
        var query = GetObjectSetSomehow;
        return query.ApplyGlobalConditions(); // Just another extension with your conditions
    }
