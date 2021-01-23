    public void Foo(StringBuilder b)
    {
        // Changes the value of the parameter (b) - not seen by caller
        b = new StringBuilder();
    }
    public void Bar(StringBuilder b)
    {
        // Changes the contents of the StringBuilder referred to by b's value -
        // this will be seen by the caller
        b.Append("Hello");
    }
