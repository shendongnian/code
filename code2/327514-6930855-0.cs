    foreach (Item entry in existingPendingItems.DefaultIfEmpty())
    {
        // (the contents of the loop is unchanged)
        if (entry != null) // fold the itemToAdd into the existing entry
        {
            entry.Quantity += itemToAdd.Quantity; // amongst other things
        }
        else // create a new entry
        {
            entry = Mapper.Map<ItemDto, Item>(itemToAdd);
        }
        Save(entry);
    }
