    var itemsToBeRemoved = new List<T>();
    foreach (T item in myHugeList) 
    {
        if (/*<condition>*/)
             itemsToBeRemoved.Add(item);
    }
    myHugeList.RemoveRange(itemsToBeRemoved);
