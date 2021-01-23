    public static void Z1<T>(T t) // where T : class
    {
        Func(t); //error there
    }
    public static void Z2<T>(T t) where T : class
    {
        Func(t); //ok 
    }
