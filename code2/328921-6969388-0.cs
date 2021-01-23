    public bool CanRemoveFromItemInventory(string item)
    {
        var pair = ItemInventory.FirstOrDefault(pair => pair.Key.GetName() == item);
    
        return pair != null && pair.Value >= 1;
    }
