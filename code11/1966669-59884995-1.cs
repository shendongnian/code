    public IQueryable<T> Fields<T>(string spaceFunction, string category, string source) where T : Entity
    {
        return _dbContext.Set<T>().Where(s => s.SpaceFunction == spaceFunction
                                  && s.Category == category &&
                                  s.LightingSource.Name == source);
    }
