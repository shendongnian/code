    foreach(string groupName in objRegex.GetGroupNames())
    {
       if (objMatch.Groups[groupName].Success)
          Trace.WriteLine(groupName);
    }
