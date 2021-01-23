    public Dictionary<string, string> Test()
    {
        List<String> myList = new List<String> { "A", "B" };
        var myDict = new Dictionary<String, Dictionary<String, String>>();
        var values = new Dictionary<string, string>{{"A_1", "1"},{"A_2", "2"},{"X_1", "3"},{"X_2", "4"},{"B_1", "5"}};
        myDict.Add("ONE", values);
        var values2 = new Dictionary<string, string>{{"Y_1", "1"},{"B_9", "2"},{"A_4", "3"},{"B_2", "6"},{"X_3", "7"}};
        myDict.Add("TWO", values2);
        var usedValues = new Dictionary<string, string>(); //reverse val/key
        var result = new Dictionary<string, string>();
        foreach (KeyValuePair<string, Dictionary<string, string>> internalDicts in myDict)
        {
            foreach (KeyValuePair<string, string> valuePair in internalDicts.Value)
            {
                bool add = false;
                if (KeyInList(myList, valuePair.Key))
                {
                    string removeKey;
                    if (usedValues.TryGetValue(valuePair.Value, out removeKey))
                    {
                        if (KeyInList(myList, removeKey)) continue;
                        result.Remove(removeKey);
                        usedValues.Remove(valuePair.Value);
                    }
                    add = true;
                }
                if (result.ContainsValue(valuePair.Value) && !add) continue;                    
                result[valuePair.Key] = valuePair.Value;
                usedValues[valuePair.Value] = valuePair.Key;
            }
        }
        return result;
    }
    private bool KeyInList(List<string> myList, string subKey)
    {
        return myList.Contains(subKey.Substring(0, 1));
    }
