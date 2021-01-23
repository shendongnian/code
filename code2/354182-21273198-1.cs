        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.Timers;
        
        namespace MyAppNamespace
        {
            public static class Cache
            {
                private static Timer cleanupTimer = new Timer() { AutoReset = true, Enabled = true, Interval = 60000 };
                private static readonly Dictionary<string, CacheItem> internalCache = new Dictionary<string, CacheItem>();
        
                static Cache()
                {
                    cleanupTimer.Elapsed += Clean;
                    cleanupTimer.Start();
                }
        
                private static void Clean(object sender, ElapsedEventArgs e)
                {
                    internalCache.Keys.ToList().ForEach(x => { try { if (internalCache[x].ExpireTime <= e.SignalTime) { Remove(x); } } catch (Exception) { /*swallow it*/ } });
                }
        
                public static T Get<T>(string key, int expiresMinutes, Func<T> refreshFunction)
                {
                    if (internalCache.ContainsKey(key) && internalCache[key].ExpireTime > DateTime.Now)
                    {
                        return (T)internalCache[key].Item;
                    }
        
                    var result = refreshFunction();
        
                    Set(key, result, expiresMinutes);
        
                    return result;
                }
        
                public static void Set(string key, object item, int expiresMinutes)
                {
                    Remove(key);
        
                    internalCache.Add(key, new CacheItem(item, expiresMinutes));
                }
        
                public static void Remove(string key)
                {
                    if (internalCache.ContainsKey(key))
                    {
                        internalCache.Remove(key);
                    }
                }
        
                private struct CacheItem
                {
                    public CacheItem(object item, int expiresMinutes)
                        : this()
                    {
                        Item = item;
                        ExpireTime = DateTime.Now.AddMinutes(expiresMinutes);
                    }
        
                    public object Item { get; private set; }
                    public DateTime ExpireTime { get; private set; }
                }
            }
    
    }
