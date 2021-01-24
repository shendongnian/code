    itemRelationList.AddRange(itemIds.Select(id =>
    {
        ItemRelation itemRelation = new ItemRelation();
        return new ItemRelationDisplay
        {
            ItemIdSub = id,
            ItemNameSub = itemRelation.ItemNameSub,
            ItemQuantitySub = 1
        };
    }));
