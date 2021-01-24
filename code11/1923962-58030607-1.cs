    cache.Set(key1, GetTableData<Student>(dbContext));
    cache.Set(key2, GetTableData<Class>(dbContext));
    cache.Set(key3, GetTableData<Teacher>(dbContext));
    public static IEnumerable<T> GetTableData<T> (DBContext dbContext)
    {
         return dbContext.Set<T>();
    }
