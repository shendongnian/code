    public bool Exists(Expression<Func<TEntity, bool>> func)
    {
        return _context.Set<TEntity>()
                       .Where(func)
                       .Any();
    }
