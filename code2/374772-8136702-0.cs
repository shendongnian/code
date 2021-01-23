    public MethodB()
    {
        ExternalObject.Click += () => { return 10; };
    }
    public MethodC()
    {
        ExternalObject.Click -= () => { return 10; };
    }
