    HashSet<long> existing = new HashSet<long>(list);
    for (long x = 0; x < long.MaxValue; x++)
    {
        if (!existing.Contains(x))
        {
            return x;
        }
    }
    throw new InvalidOperationException("Somehow the list is enormous...");
