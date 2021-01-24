    foreach (KeyValuePair<string, TestData> entry in data)
    {
        var entryName = entry.Value.GetType().GetProperty("Name").GetValue(entry.Value, null);
        var entrySection = entry.Value.GetType().GetProperty("Section").GetValue(entry.Value, null);
    }
