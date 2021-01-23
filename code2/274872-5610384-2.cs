    List<int> toRemove = new List<int>();
    foreach (KeyValuePair<int, int> pair in dictionary)
    {
        if (pair.Value < 0)
        {
            toRemove.Add(pair.Key);
        }
    }
    foreach (var key in toRemove)
    {
        dictionary.Remove(key);
    }
