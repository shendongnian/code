    public IEnumerable<Titem> GetItems(Tpriority priority)
    {
        var validKeys = value.Keys.Where(x => !x.Equals(priority) );
        return value
            .Where(x => validKeys.Contains(x.Key))
            .SelectMany(x => x.Value);
    }
