    void Foo (ref StringBuilder x) {
        x = null;
    }
    
    ...
    
    StringBuilder y = new StringBuilder();
    y.Append ("hello");
    Foo (ref y);
    Console.WriteLine (y==null); // will write TRUE
