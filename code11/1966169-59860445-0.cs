    var keysToRemove = new List<string>();
    foreach (var stackOfItems in ItemStack)
    {
        string Name = stackOfItems.Key;
        string Price= stackOfItems.Value;
        if (listOfSelectedOldItems.Contains(Name))
        {
            keysToRemove.Add(Name);
        }
    }
    foreach (var key in keysToRemove)
    {
        ItemStack.Remove(key);
    }
