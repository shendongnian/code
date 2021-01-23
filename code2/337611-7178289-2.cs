    foreach (var item in myDic)
    {
        if (!blacklist.Contains(item.Key))
        {
            if (condition)
                blacklist.Add(item.key + 1);
        }
    }
