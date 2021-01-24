    if (item.IsMainItem == true)
    {
         ItemDisplay itemDisplay = new ItemDisplay();
         itemDisplay.ItemCode = item.ItemCode;
         itemDisplay.ItemName = item.ItemName;
         itemDisplay.ItemPrice = simpleItem.ItemPrice;
         itemDisplay.Quantity = 1;
         itemDisplayList.Add(itemDisplay);
         ItemRelationBO itemRelationBO = new ItemRelationBO();
         List<int> itemIds = itemRelationBO.GetItemRelationItem(item.ItemId);
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
    }
