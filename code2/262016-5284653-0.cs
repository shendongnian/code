    public static string RemoveFromEnd(this string str, string toRemove)
    {
        if (str.EndsWith(toRemove))
            return str.Substring(0, str.Length - toRemove.Length);
        else
            return str;
    }
