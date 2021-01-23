    void Foo(){
       Type type GetTypeT(data as dynamic);
    }
    private static Type GetTypeT<T>(IEnumerable<T> data)
    {
        return typeof(T);
    }
