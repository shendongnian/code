    bool isFound = false;
    SomeClass targetItem = null;
    foreach (var item in list)
    {
        if (isFound)
        {
            item.IsPreferred = true;
            targetItem.IsPreferred = false;
            break;
        }
        if (item.IsPreferred)
        {
            targetItem = item;
            isFound = true;
        }
    }
