    ItemDto itemToAdd; // an input parameter to the method
    if (existingPendingItems.Count > 0)
    {
        foreach(Item entry in existingPendingItems)
        {
            entry.Quantity += Mapper.Map<ItemDto, Item>(itemToAdd);    
            Save(entry);
        }
    }
    else
    {
        entry = Mapper.Map<ItemDto, Item>(itemToAdd);
        Save(entry);
    }
