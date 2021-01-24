       public async Task<ICollection<TEntity>> GetAllAsync(Expression<Func<TEntity, object>>[] includes = null)
        {
            var query = DbSet.AsQueryable();
            if (includes != null)
            {
                query = includes.Aggregate(query,
                  (current, include) => current.Include(include));
            }
            return await query.ToListAsync();
        }
