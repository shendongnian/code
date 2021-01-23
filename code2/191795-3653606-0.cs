    void Foo( ref string s )
    {
        s = "Hello World"; // caller sees the change to s
    }
    // or, alternatively...
    void Bar( out string s )
    {
        s = "Hello World"; 
    }
