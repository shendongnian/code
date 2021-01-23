    using System.Linq;
    ...
    IOrderedEnumerable<KeyValuePair<TKey, TValue>> sortedDict = dict
                     .OrderByDescending(x => x.Value)
                     .ThenByDescending(x => x.Key);
Then use ToDictionary() to parse into a new dictionary if needed.
