    public FooBar(string fooBar)
        : this(fooBar.Split(new char[] { ':' }))
    {
    }
    private FooBar(string[] s)
        : this(s[0], s[1])
    {
    }
    public FooBar(string foo, string bar)
    {
    ...
    }
