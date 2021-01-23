    T[] ArrayAggregate<T>(Func<IEnumerable<T>, T> aggregate, params T[][] arrays)
    {
        return Enumerable.Range(0, arrays[0].Length)
                   .Select(i => aggregate(arrays.Select(a => a.Skip(i).First())))
                   .ToArray();
    }
