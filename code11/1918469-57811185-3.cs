    static void Main(string[] args)
    {
        string Hello(string s)
        {
            return s;
        }
        
        dynamic d = null;
        var result = Hello(d);
        Console.WriteLine("Hello World!");
    }
