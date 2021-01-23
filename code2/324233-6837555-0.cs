    public Expression<Func<T, bool>> GetIdEqualsExpression(int id)
    {
        var idProp = typeof(T).GetProperty("ID");
        var param = Expression.Parameter(typeof(T), "t");
        return Expression.Lambda<Func<T, bool>>(
            Expression.Equal(Expression.PropertyOrField(param, "ID"),
            Expression.Constant(id)), param);
    }
    public virtual T Get(int id)
    {
       return ObjectSet.AsQueryable().Single(GetIdEqualsExpression(id));
    }
