    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    ...
    
    public static readonly ReadOnlyDictionary<string,
        ConcurrentQueue<string>> Logs = CreateLogMap();
    ...
    private static ReadOnlyDictionary<string, ConcurrentQueue<string>> CreateLogMap()
    {
        var map = new Dictionary<string, ConcurrentQueue<string>>()
        {
            {"Info", new ConcurrentQueue<string>() },
            {"Warn", new ConcurrentQueue<string>() },
            {"Error", new ConcurrentQueue<string>() }
        };
        return (new ReadOnlyDictionary<string, ConcurrentQueue<string>>(map));
    }
