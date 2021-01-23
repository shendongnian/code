    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> list, int size)
    {
        var r = new Random();
        var shuffledList = 
            list.
                Select(x => new { Number = r.Next(), Item = x }).
                OrderBy(x => x.Number).
                Select(x => x.Item).
                Take(size); // Assume first @size items is fine
        return shuffledList.ToList();
    }
