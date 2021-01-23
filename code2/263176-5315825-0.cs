    public IEnumerable<MyObject> MyWhere(IEnumerable<MyObject> dataSource, Func<MyObject, bool> predicate)
    {
        foreach(MyObject item in dataSource)
        {
            if(predicate(item)) yield return item;
        }
    }
