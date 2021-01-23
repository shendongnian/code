    private void AddItemToDictionary(HybridDictionary dictionary, object key, object value)
    {
        if (!dictionary.Contains(key))
        {
            dictionary.Add(key, value);
        }
    }
    AddItemToDictionary(rtfColor, RtfColor.Black, RtfColorDef.Black);
    AddItemToDictionary(rtfColor, RtfColor.White, RtfColorDef.White);
    AddItemToDictionary(rtfColor, RtfColor.Red, RtfColorDef.Red);
