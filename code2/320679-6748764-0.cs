    List<Item> items = ...
    
    // If you mean remove any of the duplicates arbitrarily 
    List<Item> filteredItems = items.GroupBy(item => new { item.number, item.supplier })
                                    .Select(group => group.First())
                                    .ToList();
    
    // If you mean remove all of the ones that have a duplicate
    List<Item> filteredItems = items.GroupBy(item => new { item.number, item.supplier })
                                    .Where(group => group.Count() == 1)
                                    .Select(group => group.Single())
                                    .ToList();
