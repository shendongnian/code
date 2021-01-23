    public void Dispose()
    {
        Console.WriteLine("During dispose: {0}", n);
    }
    var sss = new MyStruct();
    
    using (sss)
    {
        sss.n = 12;
        Console.WriteLine("In using: {0}", sss.n); // 12
    }
    
    Console.WriteLine("Outside using: {0}", sss.n); // 12
