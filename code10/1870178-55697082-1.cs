    public static void Method<T>(ref T flag) where T : struct, IBool
    {
        if (flag.IsTrue())
        {
            Console.WriteLine(42);
        }
        else
        {
            Console.WriteLine(24);
        }
    }
