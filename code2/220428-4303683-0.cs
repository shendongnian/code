    public static List<string> SplitAndCombine(IEnumerable<string> source,
                                               string delimiter)
    {
        List<string> result = new List<string>();
        StringBuilder current = null;
        // Ignore anything before the first delimiter
        foreach (string item in source.SkipWhile(x => x != delimiter))
        {
            if (item == delimiter)
            {
                if (current != null)
                {
                    result.Add(current.ToString());
                }
                current = new StringBuilder();
            }
            current.Append(item);
        } 
        if (current != null)
        {
            result.Add(current.ToString());
        }
        return result;
    }
