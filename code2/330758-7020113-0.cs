    Dictionary<int, int> dict1 = new Dictionary<int, int>();
    Dictionary<int, int> dict2 = new Dictionary<int, int>();
    IEnumerable<int> keys1ExceptKeys2 = dict1.Keys.Except(dict2.Keys);
    IEnumerable<int> keys2ExceptKeys1 = dict2.Keys.Except(dict1.Keys);
    IEnumerable<int> keysIntersect = dict1.Keys.Intersect(dict2.Keys);
