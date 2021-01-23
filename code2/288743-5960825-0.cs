    private static void WithoutRef(string s)
    {
        s = "abc";
    }
    
    private static void WithRef(ref string s)
    {
        s = "abc";
    }
    
    private static void Main()
    {
        string s = "123";
        
        WithoutRef(s);
        Console.WriteLine(s); // s remains "123"
        
        WithRef(ref s);
        Console.WriteLine(s); // s is not "abc"
    }
