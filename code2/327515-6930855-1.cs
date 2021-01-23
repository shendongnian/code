    foreach (Item entry in existingPendingItems.DefaultIfEmpty())
    {
        Item entryToSave;
        if (entry != null) // fold the itemToAdd into the existing entry
        {
            entry.Quantity += itemToAdd.Quantity; // amongst other things
            entryToSave = entry;
        }
        else // create a new entry
        {
            entryToSave = Mapper.Map<ItemDto, Item>(itemToAdd);
        }
        Save(entryToSave);
    }
