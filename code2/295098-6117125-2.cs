    IEnumerable<T> AllCombinations<T>() where T : struct
    {
        // Constuct a function for OR-ing together two enums
        Type type = typeof(T);
        var param1 = Expression.Parameter(type);
        var param2 = Expression.Parameter(type);
        var orFunction = Expression.Lambda<Func<T, T, T>>(
            Expression.Convert(
                Expression.Or(
                    Expression.Convert(param1, type.GetEnumUnderlyingType()),
                    Expression.Convert(param2, type.GetEnumUnderlyingType())),
                type), param1, param2).Compile();
        var initalValues = (T[])Enum.GetValues(type);
        var discoveredCombinations = new HashSet<T>(initalValues);
        var queue = new Queue<T>(initalValues);
        // Try OR-ing every inital value to each value in the queue
        while (queue.Count > 0)
        {
            T a = queue.Dequeue();
            foreach (T b in initalValues)
            {
                T combo = orFunction(a, b);
                if (discoveredCombinations.Add(combo))
                    queue.Enqueue(combo);
            }
        }
        return discoveredCombinations;
    }
