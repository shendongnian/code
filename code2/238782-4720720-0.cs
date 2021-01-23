    public int GetPreviousKey(int currentKey, SortedDictionary<int, int> dictionary)
    {
        int previousKey = int.MinValue;
        foreach(KeyValuePair<int,int> pair in dictionary)
        {
            if(pair.Key == currentKey)
            {
                if(previousKey == int.MinValue)
                {
                    throw new InvalidOperationException("There is no previous key.");
                }
                return previousKey;
            }
            else
            {
                previousKey = pair.Key;
            }
        }
    }
