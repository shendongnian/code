    public void Foo(Action unique)
    {
       // Code [Common]
       unique();
       // Code [Common]
    }
    private void StartCode()
    {
        // Code [Start]
    }
    private void EndCode()
    {
        // Code [End]
    }
    // call it
    Foo(StartCode);
