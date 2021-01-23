    public Expression<Func<TEntity, bool>> And(Expression<Func<TEntity, bool>> ex1, 
                                               Expression<Func<TEntity, bool>> ex2)
    {
        var parameter = Expression.Parameter(typeof(TEntity));
        return Expression.Lambda<Func<TEntity, bool>>(  
                   Expression.And(
                       Expression.Invoke(ex1, parameter), 
                       Expression.Invoke(ex2, parameter)), 
               parameter); 
    }
