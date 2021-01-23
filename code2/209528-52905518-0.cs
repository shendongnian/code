    static void Main(string[] args)
    {
        Func(Class1.NULL);
    }
    
    void Func(Class1 a)
    { }
    
    void Func(Class2 b)
    { }
    
    class Class1
    {
        public static readonly Class1 NULL = null;
    }
    
    class Class2
    {
        public static readonly Class2 NULL = null;
    }
