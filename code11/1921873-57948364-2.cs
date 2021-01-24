    var random = new Random();
    int[] indices;
    while (true)
    {
        indices = Enumerable.Range(0,3000)
            .Select
            (
                i => random.Next(0, myLargeArray.GetUpperBound(0)) 
            )
            .Distinct()
            .Take(2000)
            .ToArray();
        if (indices.Length == 2000) break;
    }
    var randomItems = indices
        .Select
        (
            i => myLargeArray[i]
        )
        .ToList();
