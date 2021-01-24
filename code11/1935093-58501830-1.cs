    public static IEnumerable<int> IndicesOfStandaloneElements<T>(IEnumerable<T> elements)
    {
        int index = 0;
        T previous = default;
        T current  = default;
        var comparer = EqualityComparer<T>.Default;
        foreach (var next in elements)
        {
            if (index == 1)
            {
                if (!comparer.Equals(current, next))
                    yield return 0;
            }
            else if (index >= 1)
            {
                if (!comparer.Equals(current, previous) && !comparer.Equals(current, next))
                    yield return index - 1;
            }
            previous = current;
            current  = next;
            ++index;
        }
        if (index > 0 && !comparer.Equals(current, previous))
            yield return index - 1;
    }
