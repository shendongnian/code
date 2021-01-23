    private string foo;
    public string Foo
    {
        get { return foo; }
        set
        {
            if (value.Length > 5)
            {
                throw new ArgumentException("value");
            }
            foo = value;
        }
    }
