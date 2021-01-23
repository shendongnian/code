    public static int[] SmallestWindow(int[] inputArray, int[] queryArray)
    {
        var indexed = queryArray
            .SelectMany(x => inputArray
                                 .Select((y, i) => new
                                     {
                                         Value = y,
                                         Index = i
                                     })
                                 .Where(y => y.Value == x))
            .OrderBy(x => x.Index)
            .ToList();
