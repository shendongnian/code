    public TEntity FindByInclude(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
            {
                IQueryable<TEntity> result = dbSet.Where(predicate);
    
    
                if (includeProperties.Any())
                {
                    foreach (var includeProperty in includeProperties)
                    {
                        result = result.Include(includeProperty);
                    }
                }
    
                var firstResult = result.FirstOrDefault(predicate);
    
                if (firstResult != null)
                    dbSet.Attach(firstResult);
    
                return firstResult;
            }
    
            public IEnumerable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
            {
                IQueryable<TEntity> result = dbSet.AsNoTracking();
    
                return includeProperties.Aggregate(result, (current, includeProperty) => current.Include(includeProperty));
            }
