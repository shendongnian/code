    private void Start()
    {
        this.Invoke(DoSomething, 1);
        this.Invoke(DoSomethingElse, 2);
        this.Invoke(YouGetThePoint, 3);
    }
    
    // will be executed 1 second after start
    private void DoSomething()
    { ... }
    
    // will be executed 2 seconds after start
    private void DoSomethingElse()
    { ... }
    
    // will be executed 3 seconds after start
    private void YouGetThePoint()
    { ... }
