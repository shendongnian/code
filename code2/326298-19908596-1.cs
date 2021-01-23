    public void AddItem(string Name, string Value)
    {
        // ...
        // this WriteLine will block the main thread long enough,
        // so that the thread of the MemoryCache can do its work more frequently
        Console.WriteLine("...");
    }
