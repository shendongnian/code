    public T GetById<TEntity, TPKey>(TPKey id, DataContext context) where TEntity : class
    {
            MetaTable metaTable = context.Mapping.GetTable(typeof(TEntity));
            MetaDataMember primaryKeyMetaDataMember = metaTable.RowType.DataMembers.SingleOrDefault(d => d.IsPrimaryKey);
            return context.GetTable<TEntity>().SingleOrDefault(GetEqualityLambdaExpression<TEntity>(primaryKeyMetaDataMember.Name, id));
    }
