    public List<TEntity> GetEntities<TEntity>(int[] ids)
    {
        if (!ids.Any())
            return new List<TEntity>();
    
        var someDbSet = new DbSet<TEntity>();
        var resultQ = someDbSet.Where(t => ids.Contains(t.ID));
        return resultQ.toList();
    }
