    static void Main(string[] args)
    {
        object[] objs = GetInitialData();
        var accessor = GetGetterHelper<int>(objs[0].GetType(), "Number");
        var res = from a in objs where accessor(a) == 7 select a;
    }
    static Func<object, T> GetGetterHelper<T>(Type type, string methodName)
    {
        var methodInfo = type.GetProperty(methodName).GetGetMethod();
        return x => (T)methodInfo.Invoke(x, new object[] {});
    }
