    public double GetAvgResult()
    {
        // Assumes GetWeeklyValues() never returns null.
        return GetWeeklyValues().DefaultIfEmpty().Average();
    }
