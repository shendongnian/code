    private Func<T> GetNewEntity;
    protected ActiveRecordSQL() // constructor
    {
        GetNewEntity = DefaultGetNewEntity;
    }
    protected Result<T> GetWithCustomEntity(SqlCommand cmd, Func<T> GetCustomEntity)
    {
        GetNewEntity = GetCustomEntity;
        return Get(cmd);
    }
    private T DefaultGetNewEntity()
    {
        return new T();
    }
    protected T Populate(DataRow row, T existing)
    {
        T entity = existing ?? GetNewEntity();
        entity.Populate(row);
        return entity;
    }
