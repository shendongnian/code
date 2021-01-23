    public bool IsDictionaryAMatch(Dictionary<string, List<string>> dictionaryToCheck)
    {
        foreach(var kvp in dictionaryToCheck)
        {
             // Do the Keys Match
             if(!goodDictionary.Exists(x => x.Key == kvp.Key))
                 return false;
             foreach(var valueElement in kvp.Value)
             {
                  // Do the Values in each list match
                  if(!goodDictionary[kvp.Key].Exists(x => x == valueElement))
                      return false;
             }
        }
        return true;
    }
