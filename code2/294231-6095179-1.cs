    var selections = new Dictionary<string, string>()
    {
        { "1401", "AutoRepickAfterCAlignError" },
        { "2221", "AutoRepickAfterCAlignError" },
        { "1501", "AutoRepicksAfterManualRecovery" },
        { "2041", "AutoRepicksAfterManualRecovery" },
        // etc
    };
    if (selections.ContainsKey(subNumbers))
        retStr = selections[subNumbers];
