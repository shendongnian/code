    public static void Test1(object obj)
    {
        foreach(var value in (List<string>)obj)
        {
            Console.WriteLine(value);
        }
    }
