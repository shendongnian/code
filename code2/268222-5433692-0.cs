    public static IList<T> Bar<T>(this DataTable table, Action<T> postProcess)
    {
        IList<T> list = ... // do something with DataTable
    
        foreach(T item in list)
        {
            postProcess(item);
        }
    
        return list;
    }
