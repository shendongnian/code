    ...
    if (dependencies != null)
    {
        var monitor = MemoryCache.Default.CreateCacheEntryChangeMonitor(dependencies);
        monitor.NotifyOnChanged(delegate { OnChangedCallback(dependencies); });
        policy.ChangeMonitors.Add(monitor);
    }
    ...
    private static void OnChangedCallback(object state)
    {
        var keys = (IEnumerable<string>) state;
        if (keys != null)
            Logger.InfoFormat("callback - {0}", string.Join("|", keys.ToArray()));
        else
            Logger.InfoFormat("callback - null");
    }
