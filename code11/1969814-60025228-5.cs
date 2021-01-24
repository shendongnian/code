    // indexed contains result of assignment
    var indexed = temp["OtherAs"] = new List<Dictionary<string, object>>
    {
        new Dictionary<string, object>
        {
            ["Points"] = 1999
        }
    };
    // value is set to result of assignment from previous step
    ["MyA"] = indexed:
    // temp is discarded
