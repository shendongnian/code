    private static int TotalItemsInLists(params IEnumerable[] lists)
    {
        if(lists == null)
           throw new ArgumentNullException("lists");
    
        return lists.Sum(l => l == null ? 0 : GetCount(l));      
    }
    private static int GetCount(IEnumerable source)
    {
        var collection = source as ICollection;
        if (collection != null)
            return collection.Count;
    
        var genCollType = source.GetType().GetInterfaces()
                          .FirstOrDefault
                          (i => i.IsGenericType 
                           && i.GetGenericTypeDefinition() == typeof(ICollection<>));
    
        if (genCollType != null)
            return (int)genCollType.GetProperty("Count").GetValue(source, null);
    
        return source.Cast<object>().Count();
    }
