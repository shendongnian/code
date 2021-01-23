    public virtual T Get(
        int PrimaryKey)
    {
        var param = Expression.Parameter(typeof(T));
        // create expression for param => param.TEntityNameId == PrimaryKey
        var lambda = Expression.Lambda<Func<T, bool>>(
            Expression.Equal(
                Expression.Property(param, TEntityName + "Id"),
                Expression.Constant(PrimaryKey)),
            param);
        return this.Repository.Single(lambda);
    }
