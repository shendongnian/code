    public static void UpdateAll<T>(this List<T> items, T newValue)
    {
        for (var i = 0; i < items.Count; i++)
        {
            items[i] = newValue;
        }
    }
    // Usage
    var items = new List<bool> { false, false, false };
    items.UpdateAll(true);
