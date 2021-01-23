    private static string ConvertToString(List<string> list)
    {
        if (!list.Any())
        {
            return string.Empty;
        }
    
        if (list.Count == 1)
        {
            return list[0];
        }
    
        return string.Join(", ", list.GetRange(0, list.Count - 1)) + " and " + list[list.Count - 1];
    }
