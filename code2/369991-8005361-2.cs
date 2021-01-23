    list = new Operator()
        .Operate(list)
        .ToList(); // Note: Important!
    // ...
    public IEnumerable<IDated> Operate(IEnumerable<IDated> objects)
    {
        return objects.Where(o => o.Date.HasValue);
    }
