    public static IEnumerable<T> CreateEnumerable<T>(params T[] values) =>
        return values.AsEnumerable();
    //And then use it
    IEnumerable<string> myStrings = CreateEnumerable("first item", "second item");//etc..
    
