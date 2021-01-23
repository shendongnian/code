    foreach (var item in myDic)
    {
        if (!blacklist.Contains(x.Key))
        {
            if (condition)
                blacklist.Add(item.key + 1);
        }
    }
