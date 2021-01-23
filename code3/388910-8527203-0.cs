    object CreateTypeFrom()
    {
        var A = Assembly.LoadFrom(@"xxxx");
        return A.CreateInstance("T");
    }
    void Test()
    {
        object t = CreateTypeFrom();
        T RealT = new T(); // no prob
        T Castedt = (T)t; // this will throw an InvalidCastException
        T isNull = t as T; // this will result in a null instance
    }
