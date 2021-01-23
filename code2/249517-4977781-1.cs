    int endOfOne = TwoNames.IndexOf("@2");
    if (endOfOne != -1)
    {
        nameOne = TwoNames.Substring(0, endOfOne);
    }
    else
    {
        // Couldn't find @2... throw exception perhaps?
    }
    int startOfTwo = TwoNames.LastIndexOf("@3");
    if (startOfTwo != -1)
    {
        // Allow for the "@3" itself
        nameTwo = TwoNames.Substring(startOfTwo + 2);
    }
    else
    {
        // Couldn't find @3... throw exception perhaps?
    }
