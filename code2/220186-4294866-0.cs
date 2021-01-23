    public static void ForEach<T>(IEnumerable<T> enumerable,Action<T> action)
    {
        foreach(var item in enumerable) action(enumerable);
    }
    public static void ForEach<T>(IEnumerable<T> enumerable,Action<T,int> action)
    {
        int index = 0;
        foreach(var item in enumerable) action(enumerable,index++);
    }
