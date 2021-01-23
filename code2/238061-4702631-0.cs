    public AdvancedList(IEnumerable<T> collection)
    {
        foreach (var item in collection)
        {
            Add(item);
        }
    }
