    static void Main(string[] args)
    {
        dynamic d = null;
        var result = Hello(d);
        Console.WriteLine("Hello World!");
    }
    static string Hello(string s)
    {
        return s;
    }
    static int Hello(int i)
    {
        return i;
    }
