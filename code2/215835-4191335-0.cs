    var list = from inv in db.Inventories
               where inv.InventoryCode.StartsWith("005")
               select
               new
               {
                   inv.InventoryCode,
                   Synopsis = inv.InventoryMedias
                                 .Where(im => im.MediaType == 0)
                                 .Select(im => im.Synopsis)
                                 .FirstOrDefault(),
                   InventoryID = inv.InventoryMedias
                                    .Where(im => im.MediaType == 0)
                                    .Select(im => im.InventoryID)
                                    .FirstOrDefault(),
               };
