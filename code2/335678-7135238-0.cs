    public void AppendHello(StringBuilder builder)
    {
        // This changes the data within the StringBuilder object that the
        // builder variable refers to. It does *not* change the value of the
        // builder variable itself.
        builder.Append("Hello");
    }
