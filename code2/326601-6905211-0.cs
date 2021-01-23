    string[] names = new string[]{"a_1", "c_4", "a_5", "a_3", "b_2", "b_9", "c_10"};
    
    var splitNames = from name in names 
    let splitIdx = name.LastIndexOf("_")
    let shortName = name.Substring(0, splitIdx+1)
    let version = Convert.ToInt32(name.Substring(splitIdx+1, name.Length - splitIdx -1))
    select new {shortName, version};
    
    var nameGroups = splitNames.GroupBy(x => x.shortName).elect(group => new {group.Key, maxVersion = group.Max(x => x.version)});
    
    foreach (var g in nameGroups.OrderBy(x => x.Key))
    {
    	Console.WriteLine(g.Key + g.maxVersion);
    }
