    // TODO: Think of a better name :)
    public static string SubstringBeforeFirst(string text, string delimiter)
    {
        int index = text.IndexOf(delimiter);
        return index == -1 ? text : text.Substring(0, index);
    }
