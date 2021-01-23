    Dictionary<string, int> other = ...;
    HashSet<string> blacklist = ...;
    var dictionary = other.Where(item => item.Value > 0 && 
                                         !blackList.Contains(item.Key)
                          .ToDictionary(item => item.Key, item => item.Value);
