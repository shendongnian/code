    public static IEnumerable<string> GetEntries()
    {
        lock(lockObj)
        {
            return library_entries.Where(entry => !string.IsNullOrEmpty(entry)).ToList();
        }
    }
