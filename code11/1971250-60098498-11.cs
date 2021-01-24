    public List<TEntity> GetEntities<TEntity>(int[] ids)
    {
        var someDbSet = new DbSet<TEntity>();
        if (!ids.Any())
            return someDbSet.ToList();
    
        var resultQ = someDbSet.Where(t => ids.Contains(t.ID));
        return resultQ.toList();
    }
