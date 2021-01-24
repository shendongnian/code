    List<int> itemIds = itemRelationBO.GetItemRelationItem(item.ItemId);
    List<ItemRelation> temp = new List<ItemRelation>();
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
