    public void AddRange(IEnumerable<IEnumerable<T>> rows)
    {
        foreach(var row in rows)
        {
           Add(row)
        }
    }
