    public static ICollection<T> EnsureListExistsAndHasAtLeastOneItem(ICollection<T> source)
        where T : Officer, new()
    {
        var list = source ?? new List<T>();
        if( list.Count == 0 ) list.Add(new T());
        return list;
    }
