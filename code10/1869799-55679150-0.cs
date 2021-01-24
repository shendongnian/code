    var inventoryViewList = inventories.Select(x => new InventoryViewModel()
                {
                    Id = x.Id,
                    Name = x.Name.ToString(),
                    StorageUnits = x.StorageUnits
                }).ToList();
