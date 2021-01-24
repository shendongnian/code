    private static string[] GetCommonElements(List<string[]> list)
    {
        if (!list.Any())
        {
            return Array.Empty<string>();
        }
        IEnumerable<string> result = list[0];
        foreach (string[] collection in list.Skip(1))
        {
            result = result.Intersect(collection);
        }
        return result.ToArray();
    }
