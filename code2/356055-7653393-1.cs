    public double GetCost( int tot )
    {
        int multipliers;
        int count;
        double cost;
        var dictionary = list.ToDictionary( kvp => kvp.Key, kvp => kvp.Value );
        count = list.Count;
        multipliers = tot / count;
        cost = multipliers * dictionary[count];
        tot %= count;
        if ( dictionary.ContainsKey( tot ) )
        {
            cost += dictionary[tot];
        }
        return cost;
    }
