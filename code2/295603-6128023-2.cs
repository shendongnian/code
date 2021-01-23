    var grpFilters = (from itm in list group itm by itm.Type into grp select
                        new GroupedFilter
                        {
                            Type = grp.Key,
                            Filters = grp.Select(g => new Filter 
                                                      {
                                                          ItemID = g.ItemID,
                                                          ItemName = g.ItemName
                                                      }).ToList()
                        }).ToList();
