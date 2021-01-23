    void S<T>(int a, T b)
    {
        Console.WriteLine("generic method");
    }
    
    void S(int a, int b)
    {
        Console.WriteLine("int overload");
    }
    
    void S(int a, long b)
    {
        Console.WriteLine("long overload");
    }
...
    S(10, 10);
    S(10, (long)10);
    S(10, 10L);
    S(10, 10M);
    S<int>(10, 10); // uses generic
    S<long>(10, 10); // uses generic & implicit conversion
