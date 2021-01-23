    // placed up here, it looks kinda weird, imho
    // private int foo;
    /// <summary>
    /// The index of the Foo in the <see cref="Bar"/>
    /// </summary>
    public int Foo
    {
        get { return foo; }
        set
        {
            // validate value
            foo = value;
        }
    }
    private int foo;
