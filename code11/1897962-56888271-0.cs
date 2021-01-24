    IStandardProperties v; 
    if (items.TryGetValue("key", out v))
    {
        // found. the line below asks if the interface is supported
        var item1 = v as IItemType1;
        if (item1 != null)
        {
            // v supports IItemType1, therefore you can do something with it, by using item1
        }
        
        // we repeat for IItemType2
        var item2 = v as IItemType2;
        if (item2 != null)
        {
            // v supports IItemType2, therefore you can do something with it, by using item2
        }
    
    }
    else
    {
        // not found
    }
