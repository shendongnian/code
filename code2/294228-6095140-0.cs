    string errorCode = errorNumbers.Substring(0, 4);
    Dictionary<string, string> map = new Dictionary<string,string>();
    map.Add("1501", "AutoRepicksAfterManualRecovery");
    map.Add("2041", "AutoRepicksAfterManualRecovery");
    map.Add("1401", "AutoRepickAfterCAlignError");
    map.Add("2221", "AutoRepickAfterCAlignError");
    map.Add("1301", "AutoRepickAfterPickError");
    map.Add("2121", "AutoRepickAfterPickError");
    // etc
    
    if(!map.ContainsKey(errorCode))
     throw new Exception("Invalid error code");
    
    return map[errorCode];
