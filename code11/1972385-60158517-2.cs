    public static void TestCollectionSizes()
    {
        var slot = new GoogleAddSlot
        {
            {new AdSlotSizes {200, 300, 400} },
            {new AdSlotSizes {"fluid", "solid"}},
        };
        foreach (int size in slot[0].GetIntegerSizes())
        {
            Debug.WriteLine($"Integer Size: {size}");
        }
        foreach (string size in slot[1].GetStringSizes())
        {
            Debug.WriteLine($"String Size: {size}");
        }
    }
