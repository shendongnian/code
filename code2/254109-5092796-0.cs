    private readonly object mutex = new object();
    private Foo foo = ...;
    public Foo Foo
    {
        get
        {
            lock(mutex)
            {
                return foo;
            }
        }
    }
