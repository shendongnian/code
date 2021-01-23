    private readonly object syncRoot = new object();
    void Main(string[] args)
    {
        Foo();
        doThings();
        Bar();
    }
    void Foo()
    {
        Monitor.Enter(syncRoot);
    }
    void Bar()
    {
        Monitor.Exit(syncRoot);
    }
