    /// <summary>
    /// Clears the cache from a DataContext to insure data is refreshed
    /// </summary>
    /// <param name="dc"></param>
    public static void ClearCache(this DataContext dc)
    {
        dc.GetType().InvokeMember("ClearCache", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.InvokeMethod, null, dc, null);
    }
