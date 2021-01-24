    public IEnumerable<Entity> GetAll(
        Func<IQueryable<Entity>, IQueryable<Entity>> query)
    {
        using (var context = new DbContext())
            return query(context.Set<Entity>).ToList();
    }
    
    // usage: GetAll((entities) => entities.Where( ... ));
