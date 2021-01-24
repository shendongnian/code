    MethodInfo methodInfo = typeof(CacheSettings).GetMethod("GetTableData");
    string[] tablesToBeCached  = { "Student", "Class", "Teacher" };
    object[] parameters = new object[] { myDBContextObj };
    
    foreach(var tblToBeCached in tablesToBeCached)
    {
        string key = $"{tblToBeCached}";
        MethodInfo getTableDataMethod =         methodInfo.MakeGenericMethod(Type.GetType($"Namespace.{tblToBeCached}, AssemblyName"));
        cache.Set(key, getTableDataMethod.Invoke(null, parameters));
    }
    
    and the Get
    
    public static IEnumerable<T> GetTableData<T>(MyDBContext dbContext) where T : class
    {
       return dbContext.Set<T>();
    }
