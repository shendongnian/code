    public void DoSomethingWith(IEnumerable<string> values)
    {
        var notNullValues = values.Where(value => value != null).ToArray();
        // Do something with not null values
    }
    public void DoSomethingWith(IEnumerable<Nullable<T>> values)
    {
        var notEmptyValues = values.Where(value => value.HasValue).ToArray();
        // Do something with not null values
    }
