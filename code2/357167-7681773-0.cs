    public void DoSomething(Action yourCodeBlock)
    {
        yourCodeBlock();
    }
    public void CallingMethod()
    {
        this.DoSomething(
        {
            ... statements
        });
        this.DoSomething(
        {
            ... other statements
        });
    }
