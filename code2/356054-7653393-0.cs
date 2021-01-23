    public double GetCost( int tot )
    {
        int multipliers;
        int count;
        double cost;
        count = list.Count;
        multipliers = tot / count;
        cost = multipliers * list[count - 1].Value;
        cost += list[(tot % count)-1].Value;
        return cost;
    }
