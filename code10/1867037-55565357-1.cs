    List<int> itemIds = itemRelationBO.GetItemRelationItem(item.ItemId);
    List<ItemRelationDisplay> temp = new List<ItemRelationDisplay>();
    foreach (var id in itemIds)
    {
        ItemRelation itemRelation = new ItemRelation();
        ItemRelationDisplay itemRelationDisplay = new ItemRelationDisplay();
        itemRelationDisplay.ItemIdSub = id;
        itemRelationDisplay.ItemNameSub = itemRelation.ItemNameSub;
        itemRelationDisplay.ItemQuantitySub = 1;
        temp.Add(itemRelationDisplay);
    }
    itemRelationList.AddRange(temp)
