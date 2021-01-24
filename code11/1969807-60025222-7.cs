    new Dictionary<int, object>
    {
        [1] = "Solo",
        [2] = 88
    }
    // compiler error saying "can't convert string to int"
    // so indeed this indexer is applied to the previous dictionary
    ["OtherAs"] = new List<Dictionary<string, object>>
    {
        new Dictionary<string, object>
        {
            ["Points"] = 1999
        }
    }
