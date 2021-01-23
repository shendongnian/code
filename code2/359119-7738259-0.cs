    public void AddRange(IEnumerable<List<T>> rows)
    {
        foreach (var row in rows)
        {
            Add(row);
        }
    }
