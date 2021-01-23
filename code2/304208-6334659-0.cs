    static void M1(int y)
    {
        Console.WriteLine("val");
    }
    static void M1(ref int y)
    {
        Console.WriteLine("ref");
    }
    //static void M1(out int y)  // compile error
    //{
    //    Console.WriteLine("out");
    //}
    static void Main2()
    {
        int a = 3;
        M1(a);
        M1(ref a);
    //    M1(out a);
    }
