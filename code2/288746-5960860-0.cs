    string s = "hello world";
    Console.WriteLine(s);
    foo(s);
    Console.WriteLine(s);
    bar(ref s);
    Console.WriteLine(s);
    void foo(string x)
    {
    	x = "foo";
    }
    
    void bar(ref string x)
    {
    	x = "bar";
    }
