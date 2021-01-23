    foreach (string str in items1.ToArray())
    {
        if (isPackagePlacementOneType(str))
        {
            items1.Remove(str);
            items2.Add(str);
        } else if ...
    }
