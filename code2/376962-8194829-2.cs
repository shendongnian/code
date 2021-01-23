    public IQueryable<TEntity> ApplyOrderBy<TEntity>(IQueryable<TEntity> query,
        params IOrderByExpression<TEntity>[] orderByExpressions)
        where TEntity : class
    {
        if (orderByExpressions == null)
            return query;
        IOrderedQueryable<TEntity> output = null;
        foreach (var orderByExpression in orderByExpressions)
        {
            if (output == null)
                output = orderByExpression.ApplyOrderBy(query);
            else
                output = orderByExpression.ApplyThenBy(output);
        }
        return output ?? query;
    }
