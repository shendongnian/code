    private void ReloadIdea(IEnumerable<Item> newItems)
    {
        List<string> addedOrUpdatedKeys = new List<string>();
        foreach (Item item in newItems)
        {
            StorageItems.AddOrUpdate(item.key, item.Value, (s, o) => item.Value);
            addedOrUpdatedKeys.Add(item.key);
        }
        foreach (string key in StorageItems.Keys)
        {
            StorageItems.TryRemove(key, out var removedValue); // This is perfectly fine for a ConcurrentDictionary.
        }
    }
