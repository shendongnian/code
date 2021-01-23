    public static void TestOptional(string A, params string[] C)
    {
        TestOptional(A, 0, C);
    }
    
    public static void TestOptional(string A, int B, params string[] C)
    {
        Console.WriteLine(A);
        Console.WriteLine(B);
        Console.WriteLine(C.Count());
    }
