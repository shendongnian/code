    public static TResult As<T, TResult>(T obj)
        where TResult : class
    {
        return obj as TResult;
    }
