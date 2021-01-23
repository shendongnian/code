    ItemDto itemToAdd; // an input parameter to the method
    if (existingPendingItems.Any())
    {
        foreach(Item entry in existingPendingItems)
        {
            entry.Quantity += itemToAdd.Quantity    
            Save(entry);
        }
    }
    else
    {
        entry = Mapper.Map<ItemDto, Item>(itemToAdd);
        Save(entry);
    }
