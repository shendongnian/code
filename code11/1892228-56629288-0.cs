List<Dictionary<string, string>> igData = data.Select(x => 
    {
        var dict = new Dictionary<string, string>
        {
            ["Date"] = x.GetValueOrDefault("DATE"),
            ["SP"] = x.GetValueOrDefault("SP"),
            ["IG"] = x.GetValueOrDefault("IG")
        };
        // I hope I understand correctly that GetHalfHourlyTimeHeaders returns List<string>
        foreach (string header in headers.GetHalfHourlyTimeHeaders())
        {
            dict.Add(header, x.GetValueOrDefault("IG"));
        }
        return dict;
    }
).ToList();
