    var pendingEntries = existingPendingItems.Any()
        ? existingPendingItems
        : new List<Item> { Mapper.Map<ItemDto, Item>(itemToAdd) };
    foreach (var entry in pendingEntries)
    {
    	entry.Quantity += itemToAdd.Quantity; // amongst other things
    	Save(entry);
    }
