    public int GetAvgResult()
    {
        var weeklyvalues=GetWeeklyValues();//gets list of weekly values.
        return weeklyvalues.Count == 0
            ? 0 
            : (weeklyvalues.Sum() / weeklyvalues.Count);
    }
