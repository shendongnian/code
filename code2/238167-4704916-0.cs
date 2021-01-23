    public static void Main()
    {
        Action<string> a = name => Console.WriteLine(name);
        a(MethodInfo.GetCurrentMethod().Name);
    }
