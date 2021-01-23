    int? integer;
    double? floating;
    string str;
    if (token.Value == null)
    {
        // blah
    }
    else if ((integer = token.Value as int?) != null)
    {
        // work with integer.Value
    }
    else if ((floating = token.Value as double?) != null)
    {
        // work with floating.Value
    }
    else if ((str = token.Value as string) != null)
    {
        // work with str
    }
