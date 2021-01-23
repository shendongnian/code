    private void AddItemToDictionary(HybridDictionary dictionary, object item)
    {
        if (!dictionary.Contains(item))
        {
            dictionary.Add(item, item);
        }
    }
    AddItemToDictionary(rtfColor, RtfColor.Black);
    AddItemToDictionary(rtfColor, RtfColor.White);
    AddItemToDictionary(rtfColor, RtfColor.Red);
