    var groupedFilters = (from itm in list group itm by itm.Type into grouped select
                            new GroupedFilter
                            {
                               Type = grouped.Key,
                               Filters = (from gflt in grouped select new Filter { ItemID = gflt.ItemID, ItemName = gflt.ItemName }).ToList()
                            }
                          ).ToList();
