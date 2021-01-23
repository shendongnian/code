    public virtual TEntity GetById(int id)
    {
        var table = DataContext.GetTable<TEntity>();
        var mapping = DataContext.Mapping.GetTable(typeof(TEntity));
        var idProperty = mapping.RowType.DataMembers.SingleOrDefault(d => d.IsPrimaryKey);
        var param = Expression.Parameter(typeof(TEntity), "e");
        var predicate = Expression.Lambda<Func<TEntity, bool>>(Expression.Equal(
            Expression.Property(param, idProperty.Name), Expression.Constant(id)), param);
        return table.SingleOrDefault(predicate);
    }
