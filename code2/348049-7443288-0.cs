    Cache.Insert("MyText", someTextVariable, null, DateTime.Now.AddHours(1), 
                 TimeSpan.Zero, CacheItemPriority.High, 
                 new CacheItemRemovedCallback(ItemRemoved))
    
    
    public void ItemRemoved(string key, object value, CacheItemRemovedReason reason)
    {
        // write your refresh logic
    }
