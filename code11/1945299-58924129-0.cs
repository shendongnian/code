    foreach(var item1 in List1)
    {
        var matchingItem = List2.Where(item2 => CheckMatch(item1, item2)).FirstOrDefault();
        if (matchingItem != null)
        {
            item1.IsExclude = matchingItem.IsExcluded;
            item1.IsInclude = matchingItem.IsIncluded;
            item1.Category = matchingItem.Category;
        }
    }
