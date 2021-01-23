    public static string StringsToKey(params string[] values)
    {
        var builder = new StringBuilder();
        foreach(var s in values)
            builder.Append(s + "\0"); //the \0 is ASCII 0, used to delimit words
        return builder;
    }
