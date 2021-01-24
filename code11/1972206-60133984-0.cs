    public async Task<ICollection<TEntity>> GetAllAsync(Expression<Func<TEntity, object>>[] includes = null)
    {
        var query = _context.Set<TEntity>().AsQueryable();
        if (includes != null)
        {
            foreach (var item in includes)
            {
                query.Include(item);
            }
        }
        var result =  await query.ToListAsync();
        return result;
    }
