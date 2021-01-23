    delegate int Del(int x, int y = 456);
    static int Foo(int a, int b = 123)
    { 
        return a+b; 
    }
    
    static void Main()
    {
        Del d = Foo;
        Console.WriteLine(d(1));
    }
