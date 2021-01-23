    var set = new HashSet<T>();
    foreach (var list in listOfLists)
    {
        foreach (var item in list)
        {
            if (!set.Contains(item))
            {
               set.Add(item);
            }
        }
    }
    var result = set.Count;
