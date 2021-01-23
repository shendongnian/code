    static Dictionary<DateTime, int> GetSummarisedData()
    {
        var results = (
            from row in stats.AsEnumerable()
            group row by row.Field<string>("date") into grp
            select new { Date = grp.Key, Count = grp.Count(t => t["date"] != null) })
            .ToDictionary(val => val.Date, val => val.Count);
    
        return results;
    }
