    public IEnumerable<T> RemoveAll(this List<T> list, Func<bool, T> condition)
    {
       var itemsToRemove = list.Where(s => condition(s));
       list.RemoveAll(itemsToRemove);
    }
