    //// str - the source string
    //// index- the start location to replace at (0-based)
    //// length - the number of characters to be removed before inserting
    //// replace - the string that is replacing characters
    public static string ReplaceAt(this string str, int index, int length, string replace)
    {
        return str.Remove(index, Math.Min(length, str.Length - index))
                .Insert(index, replace);
    }
    
