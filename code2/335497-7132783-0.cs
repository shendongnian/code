    public void IncrementCount(Dictionary<int, int> someDictionary, int id)
    {
        if (!someDictionary.ContainsKey(id))
            someDictionary[id] = 0;
        
        someDictionary[id]++;
    }
