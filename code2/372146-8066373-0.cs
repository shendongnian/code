    object listLock = new object();
    lock(listLock)
    {
        if(!list.Contains(item))
        {
            list.Add(Item);
        }
    }
