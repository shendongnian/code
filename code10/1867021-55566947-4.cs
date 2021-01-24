    private void Start()
    {
        this.InvokeRepeated(DoSomething, 1);
        this.InvokeRepeated(DoSomethingElse, 2);
        this.InvokeRepeated(YouGetThePoint, 3);
    }
    
