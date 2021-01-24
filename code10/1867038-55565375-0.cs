    List<ItemRelationDisplay> itemRelationList = itemIds.Select(id => { 
                   ItemRelation itemRelation = new ItemRelation();
                   return new ItemRelationDisplay {
                             ItemIdSub = id,
                             ItemNameSub = itemRelation.ItemNameSub,
                             ItemQuantitySub = 1
                            };
                         }).ToList();
