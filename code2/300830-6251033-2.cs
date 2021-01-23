    private static string ConvertToString(List<string> list)
    {
        if (!list.Any())
        {
            return string.Empty;
        }
    
        if (list.Count == 1)
        {
            return list.First();
        }
    
        return string.Join(", ", list.Take(list.Count - 1)) + " and " + list.Last();
    }
