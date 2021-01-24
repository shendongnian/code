    ConfigEntity foundItem = null;
    foreach (var f in configList)
    {
        if (f.GoodCode == searchFor.GoodCode &&
            f.UserType == searchFor.UserType &&
            f.Country == searchFor.Country &&
            f.State == searchFor.State &&
            f.City == searchFor.City)
        {
            foundItem = f;
            break;
        }
    }
    if (foundItem != null)
    {
        // found the item. Do something with it.
    }
    else
    {
        // didn't find the item. Handle the error.
    }
