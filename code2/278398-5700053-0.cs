    public static string SafeToString(this Object obj)
    {
       return obj.SafeToString(string.Empty);
    }
    public static string SafeToString(this Object obj, string defaultString)
    {
       return obj == null ? defaultString : obj.ToString();
    }
