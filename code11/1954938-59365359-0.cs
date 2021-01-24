    public static List<int> RemoveSequential(List<int> items, int tolerance)
    {
        if (items == null || items.Count < 2) return items;
        var result = new List<int> {items.First()};
        var sequenceCount = 0;
        for(int i = 1; i < items.Count; i++)
        {
            if (Math.Abs(items[i] - items[i - 1]) == 1)
            {
                sequenceCount++;
                if (sequenceCount == tolerance - 1)
                {
                    result.Add(items[i]);
                }
            }
            else
            {
                sequenceCount = 0;
                result.Add(items[i]);
            }
        }
        return result;
    }
