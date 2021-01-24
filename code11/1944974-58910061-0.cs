    var test = TknType.Numeric;
    if((test & TknType.Numeric) == TknType.Numeric) 
    {
        Console.WriteLine("Test has Numeric flag");
    } 
    else if((test & TknType.Number) == TknType.Number) 
    {
        Console.WriteLine("Test has Number flag");
    }
    else if((test & TknType.Constant) == TknType.Constant) 
    {
        Console.WriteLine("Test has Constant flag");
    }
