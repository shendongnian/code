    public void CacheItemRemoved(CacheEntryRemovedArguments Args)
    {
        // this WriteLine() will block the thread of
        // the MemoryCache long enough to slow it down,
        // and it will never catch up the amount of memory
        // beyond the limit
        Console.WriteLine("...");
    
        // ...
    
        // this ReadKey() will block the thread of 
        // the MemoryCache completely, till you press any key
        Console.ReadKey();
    }
