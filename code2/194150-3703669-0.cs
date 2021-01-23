    public static Guid ToGuid(this string id)
    {
        return new Guid(id);
    }
    public Guid GetPropertyId(...)
    {
        return Select
            .Either(TryToGetTheId(...))
            .Or(TrySomethingElseToGetTheId(...))
            .Id
            .ToGuid();
    }
