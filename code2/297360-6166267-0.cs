    public void Caller1()
    {
        var builder = new StringBuilder("input");
        Console.WriteLine("Before: {0}", builder.ToString());
        ChangeBuilder(builder);
        Console.WriteLine("After: {0}", builder.ToString());
    }
    public void ChangeBuilder(StringBuilder builder)
    {
        builder.Clear();
        builder.Append("output");
    }
