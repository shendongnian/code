    public static void foo(ref object a)
    {
        a = "foo";
    }
    
    static void Main(string[] args)
    {
        string bbb = "";
        dynamic a = bbb;        // or object
        foo(ref a);
        bbb = a;                // if it was object you need to cast to string
    
        Console.WriteLine(bbb); // foo
    }
