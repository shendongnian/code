    static void Main(string[] args)
    {
        int test = 1;
        reserTest(ref test);
    
        Console.Write(test); // Should be 0 now
    }
    
    static void resetTest(ref int i)
    {
        i = 0;
    }
