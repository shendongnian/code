    public static Dictionary<string, string> Test()
    {
        int initcount = _myDict.Sum(keyValuePair => keyValuePair.Value.Count);
        var usedValues = new Dictionary<string, string>(initcount); //reverse val/key
        var result = new Dictionary<string, string>(initcount);
        foreach (KeyValuePair<string, Dictionary<string, string>> internalDicts in _myDict)
        {
            foreach (KeyValuePair<string, string> valuePair in internalDicts.Value)
            {
                bool add = false;
                if (KeyInList(_myList, valuePair.Key))
                {
                    string removeKey;
                    if (usedValues.TryGetValue(valuePair.Value, out removeKey))
                    {
                        if (KeyInList(_myList, removeKey)) continue;
                        result.Remove(removeKey);
                    }
                    usedValues.Remove(valuePair.Value);
                    add = true;
                }
                if (!add && usedValues.ContainsKey(valuePair.Value)) continue;
                result[valuePair.Key] = valuePair.Value;
                usedValues[valuePair.Value] = valuePair.Key;
            }
        }
        return result;
    }
    private static bool KeyInList(List<string> myList, string subKey)
    {
        string key = subKey.Substring(0, subKey.LastIndexOf('_'));
        return myList.Contains(key);
    }
