    void Foo( ref string s, ref int x )
    {
        s = "Hello World"; // caller sees the change to s
        x = 100;           // caller sees the change to x
    }
    // or, alternatively...
    void Bar( out string s )
    {
        s = "Hello World"; 
    }
