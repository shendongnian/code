    public IQueryable<SpaceFunctionType> Get<TDomain>(string airFlowSource)
    {
        return _dbContext.Set<TDomain>().Where(s => s.EquipmentSourceName == airFlowSource)
                              .Select(c => new SpaceFunctionType
                              {
                                  Category = c.Category,
                                  SpaceFunction = c.SpaceFunction
                              });
    }
