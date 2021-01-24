    foreach (var item in items)
    {
        // Check if the item with such API already exists in dpIndexList
        var foundItem = dpIndexList.FirstOrDefault(dpItem => dpItem.API == item.API);
        if (foundItem != null)
        {
            // Exists. Update the item in dpIndexList
            foundItem.File = item.File;
            foundItem.Location = item.Location;
        }
        else
        {
            // Doesn't exist. Adding to dpIndexList
            dpIndexList.Add(item);
        }
    }
