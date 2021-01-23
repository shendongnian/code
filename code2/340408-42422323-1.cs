    public object[] GetPrimaryKeyValues<T>(DbContext databaseContext, T item)
    {
      return ((IObjectContextAdapter)databaseContext).ObjectContext.CreateEntityKey(typeof(T).Name.Pluralize(), item).EntityKeyValues.Select(kv => kv.Value).ToArray();
    }
    
