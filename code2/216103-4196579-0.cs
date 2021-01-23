    public IEnumerable<Entity> Hierarchy
    {
        get { return GetUpwardHierarchy().Reverse(); }    
    }
    
    private IEnumerable<Entity> GetUpwardHierarchy()
    {
        for (var entity = this; entity != null; entity = entity.Parent)
            yield return entity;
    }
