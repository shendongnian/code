    private static int ParseInteger(string str)
    {
        if (str == null || str.Trim() == "")
            return 0;
        // On .NET 4 you could use this instead.  Prior .NET versions do not
        // have the IsNullOrWhiteSpace method.
        //
        // if (String.IsNullOrWhiteSpace(str))
        //    return 0;
    
        return Int32.Parse(str);
    }
