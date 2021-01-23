    public Expression<Func<TEntity, bool>> And(Expression<Func<TEntity, bool>> ex1, 
                                               Expression<Func<TEntity, bool>> ex2)
    {
      var x = Expression.Parameter(typeof(TEntity));
      return Expression.Lambda<Func<TEntity,bool>>(
        Expression.And(
          Expression.Invoke(ex1, x),
          Expression.Invoke(ex2, x)), x); 
    }
