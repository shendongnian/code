    public static IEnumerable<IEnumerable<string>> PartitionLines(
        this IEnumerable<string> source,
        Func<string, string> groupMarkerSelector,
        string delimeter)
    {
        List<string> currentGroup = new List<string>();
        foreach (string line in source)
        {
            var key = groupMarkerSelector(line);
            if (delimeter == key && currentGroup.Count > 0)
            {
                yield return currentGroup;
                currentGroup = new List<string>();
            }
            currentGroup.Add(line);
        }
        if (currentGroup.Count > 0)
            yield return currentGroup;
    }
