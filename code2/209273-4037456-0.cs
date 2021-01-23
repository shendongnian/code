    var matchingGroupNames = objRegex.GetGroupNames()
                                     .Where(name => objMatch.Groups[name].Success);
    foreach(string groupName in matchGroupNames)
    {
        Trace.WriteLine(groupName);
    }
