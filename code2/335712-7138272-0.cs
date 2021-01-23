    private T SearchStateManager(Expression<Func<T, bool>> searchCriteria)
    {
        return _context.ObjectStateManager.GetObjectStateEntries(~EntityState.Detached)
                                          .Where(e => !e.IsRelationship)
                                          .Select(e => e.Entity)
                                          .OfType<T>()
                                          .SingleOrDefault(searchCriteria.Compile());
    } 
    public T Single(Expression<Func<T, bool>> searchCriteria)
    {
        T entity = SearchStateManager(searchCriteria);
        if (entity == null)
        {
            entity = _objectSet.SingleOrDefault(searchCriteria);
        }
        return entity;
    }
