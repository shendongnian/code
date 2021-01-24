    static void Main(string[] args)
    {
        string Hello(string s)
        {
            return s;
        }
        int Hello(int s) // error - local variable or function with the same name already declared
        {
            return s;
        }
        dynamic d = null;
        var result = Hello(d);
        Console.WriteLine("Hello World!");
    }
