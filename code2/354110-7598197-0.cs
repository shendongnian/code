    public void CreateEntityFromDataRow<TEntity>(DataRow row)
     where TEntity : IDbEntity, class
    {
       MethodInfo methodInfo = typeof(T).GetMethod("BuildFromDataRow");
       TEntity instance = Activator.CreateInstance(typeof(TEntity)) as TEntity;
       instance = methodInfo.Invoke(instance, new object[] { row } ) as TEntity;
    }
