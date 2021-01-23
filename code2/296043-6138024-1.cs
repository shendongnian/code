    string s = ...
    int result;
    if (int.TryParse(s, out result))
    {
        // The string was a valid integer => use result here
    }
    else
    {
        // invalid integer
    }
