    public static IEnumerable<TFirst> Map<TFirst, TSecond, TKey>
        (
        this GridReader reader,
        Func<TFirst, TKey> firstKey, 
        Func<TSecond, TKey> secondKey, 
        Action<TFirst, IEnumerable<TSecond>> addChildren
        )
    {
        var first = this.Read<TFirst>().ToList();
        var childMap = this
            .Read<TSecond>()
            .ToList()
            .GroupBy(s => secondKey(s))
            .ToDictionary(g => g.Key, g => g.AsEnumerable());
    
        foreach (var item in first)
        {
            IEnumerable<TSecond> children;
            if(childMap.TryGetValue(firstKey(item), out children))
            {
                addChildren(item,children);
            }
        }
    
        return first;
    }
