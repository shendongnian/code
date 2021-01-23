    public static void TestMethod(ref string myString)
    {
        myString = "world";
    }
    
    static void Main(string[] args)
    {
        string s = "hello";
        Console.WriteLine(s); // output is "hello"
        TestMethod(ref s);
        Console.WriteLine(s); // output is also "hello" not "world" !?
    }
