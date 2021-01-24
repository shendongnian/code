     public IReadOnlyList<IProperty> FindPrimaryKeyProperties<T>(T entity)
            {
                return Model.FindEntityType(entity.GetType()).FindPrimaryKey().Properties;
            }
    
            public IEnumerable<object> FindPrimaryKeyValues<TEntity>(TEntity entity) where TEntity : class
            {
                return from p in FindPrimaryKeyProperties(entity)
                       select entity.GetPropertyValue(p.Name);
            }
