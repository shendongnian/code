    struct Bla
    {
        int Data;
    }
    ...
    {
        Bla a = new Bla();
        Bla b = new Bla();
        a.Data = 10;
        a.Data = 0;
    
        Console.Writeline(IsDefault(a));
        Console.Writeline(IsDefault(b));
    }
