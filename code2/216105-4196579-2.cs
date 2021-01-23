    public IEnumerable<Entity> Hierarchy
    {
        // note: buffers results
        get { return UpwardHierarchy.Reverse(); }    
    }
    
    public IEnumerable<Entity> UpwardHierarchy
    {
        get
        {
            // genuine lazy streaming
            for (var entity = this; entity != null; entity = entity.Parent)
                yield return entity;
        }
    }
