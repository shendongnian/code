    public IQueryable<SpaceFunctionType> Get<TDomain>(Expression<Func<TDomain, bool>> predicate) where TDomain: class
    {
        return _dbContext.Set<TDomain>().Where(predicate.Compile())
                              .Select(c => new SpaceFunctionType
                              {
                                  Category = c.Category,
                                  SpaceFunction = c.SpaceFunction
                          });
