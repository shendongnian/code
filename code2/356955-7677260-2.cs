    public IEnumerable<ResolveType> ResolveAll<ResolveType>()
        where ResolveType : class
    {
        return ResolveAll<ResolveType>(true);
    }
