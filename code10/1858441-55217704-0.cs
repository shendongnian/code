    foreach (KeyValuePair<string, TestData> entry in data)
    {
        var entryName = entry.GetType().GetProperty("Name").GetValue(entry.Value, null);
        var entrySection = entry.GetType().GetProperty("Section").GetValue(entry.Value, null);
    }
