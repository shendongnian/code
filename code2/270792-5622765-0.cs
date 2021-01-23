    public void UpdateFrom<T>(T updatedItem) where T : KeyedItem
    {
        var originalItem = Set<T>().Find(updatedItem.Key);
        var props = updatedItem.GetType().GetProperties(
            BindingFlags.Public | BindingFlags.Instance);
        foreach (var prop in props)
        {
            var value = prop.GetValue(updatedItem, null);
            prop.SetValue(originalItem, value, null);
        }
    }
