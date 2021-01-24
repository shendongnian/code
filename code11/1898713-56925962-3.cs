    public static ImmutableList<T> Remove<T>(this ImmutableList<T> immutableList, T item, out bool found)
    {
        found = false;
        var possibleLocation = immutableList.IndexOf(item);
        if (possibleLocation < 0)
        {
            return immutableList;
        }
        immutableList.RemoveAt(possibleLocation);
        found = true;
        return immutableList;
    }
