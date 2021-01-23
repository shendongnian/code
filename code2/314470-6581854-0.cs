    int index = 0;
    foreach (...)
    {
        ...
        string key = MapIndexToKey(index);
        dictionary[key] = value;
        index++;
    }
    ...
    private static string MapIndexToKey(int index)
    {
        return index < 26 ? ((char) (index + 'A')).ToString()
                          : ... whatever;
    }
