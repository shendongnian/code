    public IQueryable<SpaceFunctionType> Get<TDomain>(Expression<Func<TDomain, bool>> predicate) where TDomain: IA
    {
        return _dbContext.Set<TDomain>().Where(predicate)
                              .Select(c => new SpaceFunctionType
                              {
                                  Category = c.Category,
                                  SpaceFunction = c.SpaceFunction
                          });
