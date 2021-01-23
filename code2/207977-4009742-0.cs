    var dictionary = new Dictionary<string, int>();
    using (var iterator = strings.GetEnumerator())
    {
        if (!iterator.MoveNext())
        {
            // No entries
            return dictionary;
        }
        string current = iterator.Current;
        int currentCount = 1;
        while (iterator.MoveNext())
        {
            string next = iterator.Current;
            if (next == current)
            {
                currentCount++;
            }
            else
            {
                dictionary[current] = currentCount;
                current = next;
                currentCount = 1;
            }
        }
    }
    dictionary[current] = currentCount;
    return dictionary;
