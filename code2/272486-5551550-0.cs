    static void Main(string[] args)
    {
        Delegate method1 = new Action<string>(PrintOneString);
        Delegate method2 = new Action<string, string>(PrintTwoString);
        method1.DynamicInvoke("Hello");
        method2.DynamicInvoke("Hello", "Goodbye");
    }
    public static void PrintOneString(string str)
    {
        Console.WriteLine(str);
    }
    public static void PrintTwoString(string str1, string str2)
    {
        Console.WriteLine(str1);
        Console.WriteLine(str2);
    }
