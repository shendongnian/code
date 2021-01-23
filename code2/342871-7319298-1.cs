    [Flags]
    public enum MyFlags
    {
        Test = 1,
        Test2 = 2
    }
    MyFlags flags = default(MyFlags);
    Console.WriteLine(flags); // oops
