    public override IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities)
    {
        foreach (var entity in entities)
        {
            _data.Add(entity);
        }
        return entities;
    }
