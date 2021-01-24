    public T Fields<T>(string spaceFunction, string category, string source)
    {
        Type tt = typeof(T);
        if(tt == typeof(IQueryable<LibraryEnvironment>))
            return _dbContext.LibraryEnvironment.Where(s => s.SpaceFunction == spaceFunction
                                                            && s.Category == category &&
                                                              s.EnvironmentSource.Name == source);
        if (tt == typeof(IQueryable<LibraryEquipment>))
            return _dbContext.LibraryEquipment.Where(s => s.SpaceFunction == spaceFunction
                                                          && s.Category == category &&
                                                            s.EquipmentSource.Name == source);
        if (tt == typeof(IQueryable<LibraryLighting>))
            return _dbContext.LibraryLighting.Where(s => s.SpaceFunction == spaceFunction
                                                          && s.Category == category &&
                                                          s.LightingSource.Name == source);
        return default;
    }
