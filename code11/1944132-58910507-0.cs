    public Dictionary<string, int> CountByField(Expression<Func<TEntity, string>> field)
      =>
         _dbSet
           .Select(field)
           .GroupBy(i => i)
           .Select(i => new { Key = i.Key, Count = i.Count() })
           .ToDictionary(i => i.Key, i => i.Count);
