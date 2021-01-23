    static void Main(string[] args)
    {
        object o = "Previous value";
        o = Test2((dynamic)o);
        Trace.WriteLine(o);
    }
    static public T Test2<T>(T s)
    {
        if (typeof(T) == typeof(string))
        {
            s = (T)(object)"Hello world!";
        }
        return s;
    }
