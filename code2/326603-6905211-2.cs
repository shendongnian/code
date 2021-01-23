    string[] names = new string[]{"a_1", "c_1", "d", "a_2", "a", "b_2", "b_1", "b", "c"};
    int versionCast;
    var splitNames = from name in names 
    let splitIdx = name.LastIndexOf("_")
    let shortName = splitIdx < 0 ? name + "_" : name.Substring(0, splitIdx+1)
    let version = name.Substring(splitIdx+1, name.Length - splitIdx -1)
    let intVersion = Int32.TryParse(version, out versionCast) ? versionCast : 0
    select new {shortName, intVersion};
    
    var nameGroups = splitNames.GroupBy(x => x.shortName).Select(group => new {group.Key,  maxVersion = group.Max(x => x.intVersion)});
    
    foreach (var g in nameGroups.OrderBy(x => x.Key))
    {
    	Console.WriteLine((g.Key + g.maxVersion).Replace("_0", ""));
    }
