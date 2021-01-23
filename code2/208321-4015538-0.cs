    //really dodgy code
    public void PassMeAMethod(string text, Action method)
    {
        DoSomething(text);
        method(); // call the method using the delegate
        Foo();
    }
    
    public void methodA()
    {
        Console.WriteLine("Hello World!");
    }    
    
    public void methodB()
    {
        Console.WriteLine("42!");
    }
    
    public void Test()
    {
        PassMeAMethod("calling methodA", methodA)
        PassMeAMethod("calling methodB", methodB)
    }
