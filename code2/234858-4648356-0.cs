    private readonly Func<IDependancy> _dependancy;
    public MyService(Func<IDependancy> dependancy)
    {
        _dependancy = dependancy;
    }
    public Message Method1()
    {
        _dependancy().DoSomething();
    }
    
    public Message Method2()
    {
        _dependancy().DoSomething();  
    }
    
    public Message Method3()
    {
        _dependancy().DoSomething();  
    }
