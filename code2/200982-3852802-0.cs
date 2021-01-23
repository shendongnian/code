    public static ReturnValuesDict<TKey, int> CreateEmptyClone<TKey>(ReturnValuesDict<TKey, int> current) 
    {
        var newItem = new ReturnValuesDict<TKey, int>();
        foreach (var curr in current)
        {
            newItem.Add(curr.Key, 0);  
        }
        return newItem;
    }
