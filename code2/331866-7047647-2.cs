    var queueItems = from c in dbContext.CmQueueItems
                     join s in dbContext.ShipSetParts
                     on c.ID equals s.CmQueueItem.ID
                     group s by s.CmQueueItem.ID into grouped
                     select new
                     {
                        InventoryItemID = grouped.Key,
                        //this may need a distinct before the Count
                        ShipSets = grouped.Select(g => g.InstallLocation.ShipSetID).Count()
                     };
